using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SignalR;
using TopDownHeist.GameServer.Abstractions;
using TopDownHeist.GameServer.Exceptions;

namespace TopDownHeist.GameServer.Managers
{
    /// <summary>
    /// Class for joinging and leaving lobbys, and multiplexing incoming frames to corresponding simulations
    /// </summary>
    internal class LobbyManager : ILobbyManager
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly ILogger<LobbyManager> _logger;
        private readonly IHubContext<HeistHub> _heistHubContext;
        private readonly ConcurrentDictionary<string, LobbyContext> _lobbies = new ConcurrentDictionary<string, LobbyContext>();

        public LobbyManager(
            IServiceScopeFactory serviceScopeFactory,
            ILogger<LobbyManager> logger,
            IHubContext<HeistHub> heistHubContext)
        {
            _serviceScopeFactory = serviceScopeFactory ?? throw new ArgumentNullException(nameof(serviceScopeFactory));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _heistHubContext = heistHubContext ?? throw new ArgumentNullException(nameof(heistHubContext));
        }

        public string[] GetLobbyNames()
        {
            return _lobbies.Keys.ToArray();
        }

        public void CreateLobby(string lobbyName, string lobbyPassword)
        {
            if (string.IsNullOrEmpty(lobbyName))
            {
                throw new ArgumentException("Must not be null or empty.", nameof(lobbyName));
            }

            if (lobbyPassword == null)
            {
                throw new ArgumentNullException(nameof(lobbyPassword));
            }

            if (_lobbies.ContainsKey(lobbyName))
            {
                throw new LobbyNameAlreadyExistsException(lobbyName);
            }

            new Thread(() =>
            {
                using (var lobbyScope = _serviceScopeFactory.CreateScope())
                {
                    var newLobby = ActivatorUtilities.CreateInstance<LobbyContext>(lobbyScope.ServiceProvider);

                    newLobby.Name = lobbyName;
                    newLobby.Password = lobbyPassword;

                    if (_lobbies.TryAdd(lobbyName, newLobby))
                    {
                        newLobby.Run();
                    }
                    else
                    {
                        throw new LobbyNameAlreadyExistsException(lobbyName);
                    }
                }
            }).Start();
        }

        public async Task<bool> TryConnectToLobby(string connectionId, string lobbyName, string lobbyPassword)
        {
            if (string.IsNullOrEmpty(connectionId) || string.IsNullOrWhiteSpace(lobbyName) || lobbyPassword == null)
            {
                return false;
            }

            if (_lobbies.ContainsKey(lobbyName))
            {
                await _heistHubContext.Groups.AddToGroupAsync(connectionId, lobbyName);
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task DisconnectFromLobby(string connectionId, string lobbyName)
        {
            await _heistHubContext.Groups.RemoveFromGroupAsync(connectionId, lobbyName);
        }
    }
}

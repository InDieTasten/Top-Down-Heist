using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using TopDownHeist.GameServer.Abstractions;
using TopDownHeist.GameServer.Exceptions;
using TopDownHeist.GameServer.Simulation;

namespace TopDownHeist.GameServer.Managers
{
    /// <summary>
    /// Class for joinging and leaving lobbys, and multiplexing incoming frames to corresponding simulations
    /// </summary>
    class GameManager : IGameManager
    {
        private readonly IServiceScopeFactory serviceScopeFactory;
        private readonly ILogger<GameManager> logger;
        private readonly List<Lobby> lobbies = new List<Lobby>();
        private readonly Dictionary<string, Lobby> connections = new Dictionary<string, Lobby>();

        public GameManager(IServiceScopeFactory serviceScopeFactory, ILogger<GameManager> logger)
        {
            this.serviceScopeFactory = serviceScopeFactory;
            this.logger = logger;
        }

        public void CreateGameLobby(string connectionId, string lobbyName, string lobbyPassword)
        {
            if (string.IsNullOrEmpty(connectionId))
            {
                throw new ArgumentException("Must not be null or empty.", nameof(connectionId));
            }

            if (string.IsNullOrEmpty(lobbyName))
            {
                throw new ArgumentException("Must not be null or empty.", nameof(lobbyName));
            }

            if (lobbyPassword == null)
            {
                throw new ArgumentNullException(nameof(lobbyPassword));
            }

            lock (lobbies)
            {
                if (!connections.ContainsKey(connectionId))
                {
                    new Thread(() =>
                    {
                        using (var lobbyScope = serviceScopeFactory.CreateScope())
                        {
                            var hubContext = lobbyScope.ServiceProvider.GetRequiredService<IHubContext<HeistHub>>();
                            var lobbyLogger = lobbyScope.ServiceProvider.GetRequiredService<ILoggerFactory>().CreateLogger<Lobby>();
                            var newLobby = new Lobby(lobbyLogger, hubContext, lobbyName, lobbyPassword);

                            lock (lobbies)
                            {
                                if (lobbies.Any(l => l.LobbyName == lobbyName))
                                    throw new LobbyNameAlreadyExistsException(lobbyName);

                                lobbies.Add(newLobby);
                                connections.Add(connectionId, newLobby);
                            }

                            newLobby.Run();
                        }
                    }).Start();
                }
                else
                {
                    throw new AlreadyInLobbyException(connectionId);
                }
            }
        }

        public void JoinLobby(string connectionId, string lobbyName, string lobbyPassword)
        {

        }

        public void LeaveLobby(string connectionId)
        {
            lock (lobbies)
            {
                if (connections.TryGetValue(connectionId, out Lobby lobby))
                {
                    connections.Remove(connectionId);

                    // if no more player, stop the lobby
                    if (!connections.ContainsValue(lobby))
                    {
                        lobby.Stop();
                        lobbies.Remove(lobby);
                    }
                }
            }
        }

        public string[] GetLobbyNames()
        {
            lock (lobbies)
            {
                return lobbies.Select(l => l.LobbyName).ToArray();
            }
        }
    }
}

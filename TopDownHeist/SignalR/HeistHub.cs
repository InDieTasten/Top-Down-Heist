﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using TopDownHeist.GameServer.Lobby;

namespace SignalR
{
    internal class HeistHub : Hub
    {
        private readonly ILogger<HeistHub> _logger;
        private readonly ILobbyManager _lobbyManager;

        public HeistHub(ILogger<HeistHub> logger, ILobbyManager lobbyManager)
        {
            _logger = logger;
            _lobbyManager = lobbyManager;
        }


        public async Task JoinGameServer(string lobbyName, string password)
        {
            if (await _lobbyManager.TryConnectToLobby(Context.ConnectionId, lobbyName, password))
            {
                _logger.LogInformation("Succesfully joined lobby");
                await Clients.Client(Context.ConnectionId).SendAsync("joinLobby", true);
            }
            else
            {
                _logger.LogInformation("Failed attempt to join lobby {LobbyName}", lobbyName);
                await Clients.Client(Context.ConnectionId).SendAsync("joinLobby", false);
            }
        }

        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await base.OnDisconnectedAsync(exception);
        }
    }
}

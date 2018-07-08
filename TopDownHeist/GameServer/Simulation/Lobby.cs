using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TopDownHeist.GameServer.Simulation.World;

namespace TopDownHeist.GameServer.Simulation
{
    class Lobby
    {
        private volatile bool keepRunning;
        private readonly ILogger<Lobby> logger;
        private readonly IHubContext<HeistHub> hubContext;

        public string LobbyName { get; }
        public string LobbyPassword { get; }

        public List<Player> ConnectedPlayers { get; set; }

        public Lobby(ILogger<Lobby> logger, IHubContext<HeistHub> hubContext, string lobbyName, string lobbyPassword)
        {
            this.logger = logger;
            this.hubContext = hubContext ?? throw new ArgumentNullException(nameof(hubContext));
            LobbyName = lobbyName ?? throw new ArgumentNullException(nameof(lobbyName));
            LobbyPassword = lobbyPassword ?? throw new ArgumentNullException(nameof(lobbyPassword));
        }

        public void AddPlayerInput(string playerInput)
        {
            // Add player input to buffer for the world simulation to pick up
            // ConcurrentQueue
        }

        public void Run()
        {
            keepRunning = true;

            while (keepRunning)
            {
                Task.Delay(1000).Wait();
                logger.LogInformation($"Lobby {LobbyName} is still running.");
                // simulate world
                // publish world updates
            }
        }

        public void Stop() => keepRunning = false;
    }
}

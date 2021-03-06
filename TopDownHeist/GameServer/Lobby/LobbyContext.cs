﻿using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace TopDownHeist.GameServer.Lobby
{
    internal class LobbyContext : ILobbyContext
    {
        private readonly ILogger<LobbyContext> _logger;

        public string Name { get; set; }
        public string Password { get; set; }
        public IServiceProvider LobbyServices { get; private set; }

        public LobbyContext(IServiceProvider serviceProvider)
        {
            LobbyServices = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
            _logger = LobbyServices.GetRequiredService<ILogger<LobbyContext>>();
        }

        public void Host()
        {
            throw new NotImplementedException();
        }
    }
}

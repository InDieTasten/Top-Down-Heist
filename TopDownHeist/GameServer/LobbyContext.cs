using System;
using System.Threading;
using Microsoft.Extensions.Logging;

namespace TopDownHeist.GameServer
{
    internal class LobbyContext
    {
        private readonly ILogger<LobbyContext> _logger;

        public string Name { get; set; }
        public string Password { get; set; }

        public LobbyContext(ILogger<LobbyContext> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        internal void Run()
        {
            Thread.Sleep(TimeSpan.FromSeconds(10));
        }
    }
}

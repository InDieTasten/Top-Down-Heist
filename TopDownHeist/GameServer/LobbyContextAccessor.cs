using System.Threading;
using TopDownHeist.GameServer.Abstractions;

namespace TopDownHeist.GameServer
{
    internal class LobbyContextAccessor : ILobbyContextAccessor
    {
        private AsyncLocal<ILobbyContext> _currentLobbyContext;

        public ILobbyContext LobbyContext
        {
            get => _currentLobbyContext.Value;
            set => _currentLobbyContext.Value = value;
        }
    }
}

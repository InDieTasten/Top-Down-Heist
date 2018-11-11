using System.Threading;

namespace TopDownHeist.GameServer.Lobby
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

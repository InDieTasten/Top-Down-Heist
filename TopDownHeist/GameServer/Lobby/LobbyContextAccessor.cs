using System.Threading;

namespace TopDownHeist.GameServer.Lobby
{
    internal class LobbyContextAccessor : ILobbyContextAccessor
    {
        private readonly AsyncLocal<ILobbyContext> _currentLobbyContext = new AsyncLocal<ILobbyContext>();

        public ILobbyContext LobbyContext
        {
            get => _currentLobbyContext.Value;
            set => _currentLobbyContext.Value = value;
        }
    }
}

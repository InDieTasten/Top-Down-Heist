using System.Threading.Tasks;

namespace TopDownHeist.GameServer.Abstractions
{
    public interface IGameManager
    {
        void CreateGameLobby(string connectionId, string lobbyName, string lobbyPassword);
        void JoinLobby(string connectionId, string lobbyName, string lobbyPassword);
        void LeaveLobby(string connectionId);
    }
}
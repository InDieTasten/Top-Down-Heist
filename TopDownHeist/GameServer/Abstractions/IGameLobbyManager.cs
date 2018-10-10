using System.Threading.Tasks;

namespace TopDownHeist.GameServer.Abstractions
{
    internal interface IGameLobbyManager
    {
        void CreateGameLobby(string lobbyName, string lobbyPassword);
        Task<bool> TryConnectToLobby(string connectionId, string lobbyName, string lobbyPassword);
        Task DisconnectFromLobby(string connectionId, string lobbyName);
    }
}

using System.Threading.Tasks;

namespace TopDownHeist.GameServer.Lobby
{
    internal interface ILobbyManager
    {
        void CreateLobby(string lobbyName, string lobbyPassword);
        Task<bool> TryConnectToLobby(string connectionId, string lobbyName, string lobbyPassword);
        Task DisconnectFromLobby(string connectionId, string lobbyName);
    }
}

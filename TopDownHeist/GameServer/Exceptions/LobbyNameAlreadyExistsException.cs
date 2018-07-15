using System;
using System.Runtime.Serialization;

namespace TopDownHeist.GameServer.Exceptions
{
    [Serializable]
    internal class LobbyNameAlreadyExistsException : Exception
    {
        public string LobbyName { get; set; }

        private static string BuildMessage(string lobbyName) => $"Lobby with name {lobbyName} already exists.";

        public LobbyNameAlreadyExistsException(string lobbyName) : base(BuildMessage(lobbyName))
        {
            LobbyName = lobbyName;
        }

        public LobbyNameAlreadyExistsException(string lobbyName, Exception innerException) : base(BuildMessage(lobbyName), innerException)
        {
            LobbyName = lobbyName;
        }
    }
}
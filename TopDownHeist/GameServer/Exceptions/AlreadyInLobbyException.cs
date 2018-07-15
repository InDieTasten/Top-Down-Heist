using System;
using System.Runtime.Serialization;

namespace TopDownHeist.GameServer.Exceptions
{
    [Serializable]
    internal class AlreadyInLobbyException : Exception
    {
        public string ConnectionId { get; set; }

        private static string BuildMessage(string connectionId) => $"Connection ID {connectionId} is already connected to a lobby.";

        public AlreadyInLobbyException(string connectionId) : base(BuildMessage(connectionId))
        {
            ConnectionId = connectionId;
        }

        public AlreadyInLobbyException(string connectionId, Exception innerException) : base(BuildMessage(connectionId), innerException)
        {
            ConnectionId = connectionId;
        }
    }
}
using System;

namespace TopDownHeist.GameServer.Lobby
{
    internal interface ILobbyContext
    {
        IServiceProvider LobbyServices { get; }
        void Host();
    }
}

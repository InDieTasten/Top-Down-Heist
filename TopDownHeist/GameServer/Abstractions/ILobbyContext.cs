using System;

namespace TopDownHeist.GameServer.Abstractions
{
    internal interface ILobbyContext
    {
        IServiceProvider LobbyServices { get; }
        void Run();
    }
}

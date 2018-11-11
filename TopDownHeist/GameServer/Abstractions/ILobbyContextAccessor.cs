namespace TopDownHeist.GameServer.Abstractions
{
    internal interface ILobbyContextAccessor
    {
        ILobbyContext LobbyContext { get; }
    }
}

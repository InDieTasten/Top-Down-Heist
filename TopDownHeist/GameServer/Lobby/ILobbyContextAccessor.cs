namespace TopDownHeist.GameServer.Lobby
{
    internal interface ILobbyContextAccessor
    {
        ILobbyContext LobbyContext { get; set; }
    }
}

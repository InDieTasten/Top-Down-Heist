using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TopDownHeist.GameServer.Abstractions;

public class HeistHub : Hub
{
    private readonly ILogger<HeistHub> logger;
    private readonly IGameManager gameManager;

    public HeistHub(ILogger<HeistHub> logger, IGameManager gameManager)
    {
        this.logger = logger;
        this.gameManager = gameManager;
    }

    public Task Pong(string message)
    {
        logger.LogDebug("Pong received from {connectionId}.", Context.ConnectionId);
        return Task.FromResult(0);
    }

    public override async Task OnConnectedAsync()
    {
        gameManager.CreateGameLobby(Context.ConnectionId, Context.ConnectionId, string.Empty);
        await base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception exception)
    {
        gameManager.LeaveLobby(Context.ConnectionId);
        await base.OnDisconnectedAsync(exception);
    }
}

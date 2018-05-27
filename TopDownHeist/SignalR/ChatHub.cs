using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class ChatHub : Hub
{
    public async Task SendMessage(string user, string message)
    {
        await Clients.All.SendAsync("ReceiveMessage", user, message);
    }

    public Task SendMessageToCaller(string message)
    {
        return Clients.Caller.SendAsync("ReceiveMessage", message);
    }

    public Task SendMessageToGroups(string message)
    {
        List<string> groups = new List<string>() { "All" };
        return Clients.Groups(groups).SendAsync("ReceiveMessage", message);
    }

    public override async Task OnConnectedAsync()
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, "All");
        await base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception exception)
    {
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, "All");
        await base.OnDisconnectedAsync(exception);
    }
}

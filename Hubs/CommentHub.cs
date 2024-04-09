using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AJAX.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace AJAX.Hubs
{
    // https://learn.microsoft.com/en-us/aspnet/core/tutorials/signalr?view=aspnetcore-8.0&tabs=visual-studio-code#create-a-signalr-hub

    // https://learn.microsoft.com/en-us/aspnet/core/signalr/hubs?view=aspnetcore-8.0
    public class CommentHub : Hub
    {
        public async Task NotifyOtherAllClient(CommentViewModel productComment)
        {
            // ReceiveMessage is event's name in client side that will trigger
            await Clients.All.SendAsync("ReceiveMessage", productComment);
        }
    }
}
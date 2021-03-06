﻿using System;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace RealTimeChat.Hubs
{
    public class ChatHub:Hub
    {
        public override Task OnConnectedAsync()
        {
            Clients.Client(Context.ConnectionId).SendAsync("receiveConnId",Context.
                ConnectionId);
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            return base.OnDisconnectedAsync(exception);
        }

        public async Task receiveMsg(String msg)
        {
            MessageTemplate temp = JsonConvert.DeserializeObject<MessageTemplate>(msg);
            string fromWhom = temp.fromWhom; /// userId --> connId (from DB)

            //await Clients.Client(fromWhom).SendAsync("receiveMsg",temp.message);

            var client = Clients.AllExcept(temp.fromWhom);
            await client.SendAsync("receiveMsg", temp.message);
        }
    }
}

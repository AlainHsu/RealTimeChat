using System;
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
            string toWhom = temp.toWhom; /// userId --> connId (from DB)

            await Clients.Client(toWhom).SendAsync("receiveMsg",temp.message);

            //var client = Clients.AllExcept(temp.FromWhom);
            //await client.SendAsync("receiveMsg", temp.Message);
        }
    }
}

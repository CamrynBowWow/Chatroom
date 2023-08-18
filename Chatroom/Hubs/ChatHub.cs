using Chatroom.CoreModel;
using Microsoft.AspNetCore.SignalR;

namespace Chatroom.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendRealTimeUpdate(Message message, int conversationId)
        {
            await Clients.All.SendAsync("ReceiveRealTimeUpdate", message, conversationId);
        }
    }
}

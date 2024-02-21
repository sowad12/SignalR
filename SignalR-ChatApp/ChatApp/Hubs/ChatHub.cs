using Microsoft.AspNetCore.SignalR;

namespace ChatApp.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMsgToAll(string user,string msg)
        {
            await Clients.All.SendAsync("ReceiveMsg",user, msg);
            
        }
    }
}

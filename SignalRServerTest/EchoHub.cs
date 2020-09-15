using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace SignalRServerTest
{
    public class EchoHub : Hub
    {
        [HubMethodName("message")]
        public async Task MessageAsync(string message)
        {
            await Clients.Caller.SendAsync("message", message);
        }

    }
}

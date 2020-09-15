using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;

namespace SignalRClientTest
{
    class Program
    {
        static void Main(string[] args) => MainAsync(args).GetAwaiter().GetResult();
        static async Task MainAsync(string[] args)
        {
            var hubConnection = new HubConnectionBuilder()
                .WithUrl("http://localhost:5000/echo")
                .Build();

            hubConnection.On("message", (string msg) =>
            {
                Console.WriteLine(msg);
            });

            await hubConnection.StartAsync();

            string line;
            while ((line = Console.ReadLine()) != null)
            {
                await hubConnection.SendAsync("message", line);
            }
        }
    }
}

using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace SignalRChat
{
    [HubName("chat")]
    public class ChatHub : Hub
    {
        /// <summary>
        /// Sample use case from client:
        /// $.connection.chat.client.hello = function () { console.log('hello from client!'); };
        /// $.connection.hub.start();
        /// $.connection.chat.server.hello();
        /// </summary>

        public void Hello()
        {
            Clients.All.hello();
        }


        /// <summary>
        /// Sample use case from client:
        /// $.connection.chat.client.speak = function (msg) { console.log(msg); };
        /// $.connection.hub.start();
        /// $.connection.chat.server.saySomething('I am on client!');
        /// </summary>
        public void SaySomething(string message)
        {
            Clients.All.speak(message + " - from the server.");
        }
    }
}
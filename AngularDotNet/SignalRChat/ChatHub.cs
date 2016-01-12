using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace SignalRChat
{
    [HubName("chat")]
    public class ChatHub : Hub
    {
        public void SendMessage(SendData data)
        {
            var msg = string.Format("[{0}]: {1}", data.Name, data.Message);
            Clients.Group(data.RoomName).newMessage(msg);
        }

        public void JoinRoom(string roomName) 
        {
            Groups.Add(Context.ConnectionId, roomName);
        }

        public void LeaveRoom(string roomName)
        {
            Groups.Remove(Context.ConnectionId, roomName);
        }

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

    public class SendData
    {
        public string Message { get; set; }

        public string RoomName { get; set; }

        public string Name { get; set; }
    }
}
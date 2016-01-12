using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace SignalRChat
{
    [HubName("chat")]
    public class ChatHub : Hub
    {
        public void SendMessage(SendData data)
        {
            var msg = $"[{data.Name}]: {data.Message}";

            // Send to everyone in group except send (or use Clients.OthersInGroup)
            Clients.Group(data.RoomName, Context.ConnectionId).newMessage(msg);
            Clients.Client(Context.ConnectionId).newMessage("You: " + data.Message);
        }

        public void JoinRoom(string roomName, string name)
        {
            var msg = $"{name} has joined room {roomName}";
            Clients.OthersInGroup(roomName).newNotification(msg);
            Groups.Add(Context.ConnectionId, roomName);
        }

        public void LeaveRoom(string roomName, string name)
        {
            var msg = $"{name} has left room {roomName}";
            Clients.OthersInGroup(roomName).newNotification(msg);
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
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_Chat.Hubs
{
    public class ChatHub : Hub
    {
        public static List<Client> ConnectedUsers { get; set; } = new List<Client>();
        public void Connect(string username)
        {
            Client c = new Client()
            {
                Username = username,
                ID = Context.ConnectionId
            };
            ConnectedUsers.Add(c);
            Clients.All.updateUsers(ConnectedUsers.Count(), ConnectedUsers.Select(u => u.Username));
        }


        public void Send(string message)
        {
            var sender = ConnectedUsers.First(u => u.ID.Equals(Context.ConnectionId));
            Clients.All.broadcastMessage(sender.Username, message);
        }


        public override Task OnDisconnected(bool stopCalled)
        {
            var disconnectedUser = ConnectedUsers.FirstOrDefault(c => c.ID.Equals(Context.ConnectionId));
            ConnectedUsers.Remove(disconnectedUser);
            Clients.All.updateUsers(ConnectedUsers.Count(), ConnectedUsers.Select(u => u.Username));
            return base.OnDisconnected(stopCalled);
        }
    }


    public class Client
    {
        public string Username { get; set; }

        public string ID { get; set; }
    }

}

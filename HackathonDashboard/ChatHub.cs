using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Diagnostics;
using HackathonDashboard.Models;

namespace HackathonDashboard
{
    public class ChatHub : Hub
    {

        public override Task OnConnected()
        {
            Debug.WriteLine(string.Format("Connected: {0}", Context.ConnectionId));
            return base.OnConnected();
        }
        public override Task OnDisconnected(bool stopCalled)
        {
            Debug.WriteLine(string.Format("Disconnected: {0}", Context.ConnectionId));
            return base.OnDisconnected(stopCalled);
        }
        public void Send(String name, string message)
        {
            // Call the broadcastMessage method to update clients.
            Clients.All.broadcastMessage(name, message);
        }
        public void SendUpdatedMilestone(Team team)
        {
            Clients.All.broadcastUpdatedMilestone(team);
        }
    }
}
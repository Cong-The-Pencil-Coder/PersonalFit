using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

[HubName("Chat")]

public class ChatMessage
{
    public string UserName { get; set; }
    public string Message { get; set; }
}

//hub is a .NET class that inherits from Microsoft.AspNet.SignalR.Hub
public class ChatHub : Hub
{

    public void Send(String username, String callername, String message)
    {
        Clients.Caller.addNewMessageToPage(callername, message);
        Clients.User(username).addNewMessageToPage(message);
    }
}
    //Clients.All.receiveMessage(msg);
    //Clients.All.broadcastMessage(name, message);
    // They are all asynchonous methods
    // Clients.All.doWork();            send msg to all the clients
    // Clients.Caller.doWork();         only want to call back to the client who is caller that called the hub
    // Clients.Others.doWork();         Call every body but yourself.
    // Clients.Users("Brady").doWork(); Target one specific user.
    //public override System.Threading.Tasks.Task OnConnected()
    //{
    //    return base.OnConnected();
    //}

    //public override System.Threading.Tasks.Task OnDisconnected(bool stopCalled)
    //{
    //    _hitCount -= 1;
    //    Clients.All.onRecordHit(_hitCount);
    //    return base.OnDisconnected(stopCalled);
    //}


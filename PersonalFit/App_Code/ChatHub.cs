using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

[HubName("Chat")]

//hub is a .NET class that inherits from Microsoft.AspNet.SignalR.Hub
public class ChatHub : Hub
{
    // dont want to use static vars in web code
    // Connect to default.aspx
    static int _hitCount = 0;
    public void chatNow()
    {
        //Clients.All.hello();
        _hitCount += 1;

        //onRecordHit is calling from the server side
        Clients.All.onRecordHit(_hitCount);
    }

    public void SendMessage(String msg)
    {
        Clients.All.receiveMessage(msg);
    }

    // They are all asynchonous methods
    // Clients.All.doWork();            send msg to all the clients
    // Clients.Caller.doWork();         only want to call back to the client who is caller that called the hub
    // Clients.Others.doWork();         Call every body but yourself.
    // Clients.Users("Brady").doWork(); Target one specific user.
    public override System.Threading.Tasks.Task OnConnected()
    {
        return base.OnConnected();
    }

    public override System.Threading.Tasks.Task OnDisconnected(bool stopCalled)
    {
        _hitCount -= 1;
        Clients.All.onRecordHit(_hitCount);
        return base.OnDisconnected(stopCalled);
    }
}

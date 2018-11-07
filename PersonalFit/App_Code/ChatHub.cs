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

    public void NewContosoChatMessage(string name, string message)
       => Clients.All.addContosoChatMessageToPage(name, message);

    public void Send(String name, String message)
    {
        //Clients.All.receiveMessage(msg);
        //Clients.All.broadcastMessage(name, message);
        Clients.All.addNewMessageToPage(name, message);
        //return Clients.All.InvokeAsync("Send", message);
    }





    //public void SendMessage(string name, string message) 
    //    => Clients.All.SendMessage(new ChatMessage() { UserName = name, Message = message});


    public void SendMessage(String Name, String message)
    {
        Clients.All.SendMessage(Name, message);
    }




    //Clients.All.receiveMessage(msg);
    //Clients.All.broadcastMessage(name, message);
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

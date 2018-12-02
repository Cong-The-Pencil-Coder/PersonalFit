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
    static List<UserConnection> uList = new List<UserConnection>();
    public void Send(String who, String message)
    {
        var user = uList.Where(o => o.UserName == who);
        if (user.Any())
        {
            Clients.Client(user.First().ConnectionID).addNewMessageToPage(who, message);
        }
    }

    public override Task OnConnected()
    {
        UserConnection user = new UserConnection();
        user.ConnectionID = Context.ConnectionId;
        user.UserName = Context.QueryString["username"];
        uList.Add(user);
        return base.OnConnected();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

[HubName("Chat")]
public class Chat : Hub
{
    // dont want to use static vars in web code

    static int _hitCount = 0;
    public void chatNow()
    {
        //Clients.All.hello();
        _hitCount += 1;

        //onRecordHit is calling from the server side
        Clients.All.onRecordHit(_hitCount);
    }

    public override System.Threading.Tasks.Task OnDisconnected(bool stopCalled)
    {
        _hitCount -= 1;
        Clients.All.onRecordHit(_hitCount);
        return base.OnDisconnected(stopCalled);
    }
}

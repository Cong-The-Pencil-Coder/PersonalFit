using System;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Startup))]

public class Startup
{

    public void Configuration(IAppBuilder app)
    {
        app.MapSignalR();
       // app.MapSignalR("/signalr", new HubConfiguration());
    }
}

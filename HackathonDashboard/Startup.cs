using Owin;
using Microsoft.Owin;
using Microsoft.AspNet.SignalR;


[assembly: OwinStartup(typeof(HackathonDashboard.Startup))]
namespace HackathonDashboard
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Any connection or hub wire up and configuration should go here
            app.MapSignalR();
            //app.Map("/signalr", map =>
            //{

            //    map.RunSignalR(new HubConfiguration()
            //    {
            //        EnableJavaScriptProxies = false
            //    });
            //});
        }
    }
}
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System.Web.Mvc;

[assembly: OwinStartup(typeof(SlackSchedule.App_Start.Startup))]
namespace SlackSchedule.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "ApplicationCookie",
                LoginPath = new PathString("/" + Common.GetValueFromConfig("DefaultLang") + "/Account/Login")
            });
        }
    }
}
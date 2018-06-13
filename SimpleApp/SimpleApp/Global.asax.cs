using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SimpleApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_BeginRequest()
        {
            Record_Event("Begin Request");
        }

        protected void Application_AuthenticateRequest()
        {
            Record_Event("AuthenticateRequest");
        }

        protected void Application_PostAuthenticateRequest()
        {
            Record_Event("PostAuthenticateRequest");
        }

        private void Record_Event(string name)
        {
            List<string> eventList = Application["events"] as List<string>;
            if (eventList == null)
            {
                Application["events"] = eventList = new List<string>();
            }
            eventList.Add(name);
        }
    }
}

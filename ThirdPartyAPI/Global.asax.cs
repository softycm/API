﻿using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace ThirdPartyAPI
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            RouteTable.Routes.RouteExistingFiles = true;
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
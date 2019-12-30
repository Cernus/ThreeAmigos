using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using Microsoft.AspNet.WebFormsDependencyInjection.Unity;
using ThreeAmigos.ProductFacade;

namespace CustomerApp
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // TODO: Remove this if not used
            //https://devblogs.microsoft.com/aspnet/use-dependency-injection-in-webforms-application/
            // Dependancy Injection
            //var container = this.AddUnity();

            //container.RegisterType<IProduct, DummyProduct>();
            //container.RegisterType<IMovieRepository, XmlMovieRepository>();
        }
    }
}
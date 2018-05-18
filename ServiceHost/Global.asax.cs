using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Routing;
using Castle.Windsor;
using ServiceHost.Tools;

namespace ServiceHost
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var container = new WindsorContainer();
            RegisterWindsorEvents(container);
            Framework.Config.Bootstrapper.WireUp(container);
            AuctionManagement.Config.Bootstrapper.WireUp(container);

            GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerActivator),
                new WindsorControllerActivator(container));

            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

        private static void RegisterWindsorEvents(WindsorContainer container)
        {
#if DEBUG
            container.Kernel.ComponentDestroyed += (model, instance) =>
            {
                Debug.WriteLine($"Component Destroyed : {instance.GetType()}");
            };
            container.Kernel.ComponentCreated += (model, instance) =>
            {
                Debug.WriteLine($"Component Created : {instance.GetType()}");
            };
#endif
        }
    }
}

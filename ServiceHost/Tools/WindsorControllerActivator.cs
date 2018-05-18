using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using Castle.Windsor;

namespace ServiceHost.Tools
{
    public class WindsorControllerActivator : IHttpControllerActivator
    {
        private readonly IWindsorContainer _container;
        public WindsorControllerActivator(IWindsorContainer container)
        {
            _container = container;
        }
        public IHttpController Create(HttpRequestMessage request,
            HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            return (IHttpController)_container.Resolve(controllerType);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Framework.Application;
using Framework.Core;
using Framework.Core.Events;
using Framework.NH;

namespace Framework.Config
{
    public static class Bootstrapper
    {
        public static void WireUp(IWindsorContainer container)
        {
            container.Register(Component
                .For(typeof(TransactionCommandHandlerDecorator<>))
                .LifestyleTransient());

            container.Register(Component.For<ICommandBus>()
                .ImplementedBy<CommandBus>().LifestyleSingleton());

            container.Register(Component.For<IUnitOfWork>()
                .ImplementedBy<NHUnitOfWork>().LifestylePerWebRequest());

            container.Register(Component.For<IEventListener>()
                .Forward<IEventPublisher>()
                .ImplementedBy<EventAggregator>()
                .LifestylePerWebRequest());

            ServiceLocator.Set(new WindsorServiceLocator(container));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Domain;
using NHibernate;
using NHibernate.Event;
using NHibernate.Type;

namespace Framework.NH
{
    public class DomainEventListener : IPreInsertEventListener, IPreUpdateEventListener
    {
        public bool OnPreInsert(PreInsertEvent @event)
        {
            var session = @event.Session;
            var entity = @event.Entity;

            var type = entity.GetType();
            if (type.BaseType != null && 
                type.BaseType.IsGenericType && 
                type.BaseType.GetGenericTypeDefinition() == typeof(AggregateRootBase<>))
            {
                //Enlist event into transactions
                //var events = ((AggregateRootBase<dynamic>) entity).UncommittedEvents;
            }

            return true;
        }

        public bool OnPreUpdate(PreUpdateEvent @event)
        {
            var session = @event.Session;
            var entity = @event.Entity;

            //Enlist event into transactions
            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Core.Events;

namespace Framework.Domain
{
    public class AggregateRootBase<T> : EntityBase<T>, IAggregateRoot
    {
        private IEventPublisher Publisher { get; set; }
        public List<IEvent> UncommittedEvents { get; private set; }

        protected AggregateRootBase()
        {
            this.UncommittedEvents = new List<IEvent>();   
        }
        public AggregateRootBase(IEventPublisher publisher)
        {
            this.Publisher = publisher;
            this.UncommittedEvents = new List<IEvent>();
        }
        public void Publish<TEvent>(TEvent @event) where TEvent : IEvent
        {
            this.UncommittedEvents.Add(@event);
            this.Publisher.Publish(@event);
        }
        public void SetPublisher(IEventPublisher publisher)
        {
            Debug.Assert(this.Publisher == null);
            this.Publisher = publisher;
        }
        public void ClearEvents()
        {
            this.UncommittedEvents.Clear();
        }
    }
}

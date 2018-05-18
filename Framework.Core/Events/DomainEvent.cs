using System;

namespace Framework.Core.Events
{
    public class DomainEvent : IEvent
    {
        public Guid Id { get; private set; }
        public DateTime PublishDateTime { get; private set; }
        public DomainEvent()
        {
            this.Id = Guid.NewGuid();
            this.PublishDateTime = DateTime.Now;
        }
    }
}

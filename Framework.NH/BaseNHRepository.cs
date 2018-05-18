using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Core.Events;
using Framework.Domain;
using NHibernate;

namespace Framework.NH
{
    public abstract class BaseNHRepository<TKey,T> where T : AggregateRootBase<TKey>
    {
        protected ISession Session { get; private set; }

        private readonly IEventPublisher _publisher;
        protected BaseNHRepository(ISession session, IEventPublisher publisher)
        {
            this.Session = session;
            _publisher = publisher;
        }
        public T LoadAggregate(TKey id)
        {
            var aggregateRoot = Session.Get<T>(id);
            aggregateRoot.SetPublisher(_publisher);
            return aggregateRoot;
        }
    }
}

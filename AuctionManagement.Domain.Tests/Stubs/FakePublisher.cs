using Framework.Core.Events;

namespace AuctionManagement.Domain.Tests.Stubs
{
    public class FakePublisher : IEventPublisher
    {
        public void Publish<T>(T @event) where T : IEvent
        {
        }
    }
}

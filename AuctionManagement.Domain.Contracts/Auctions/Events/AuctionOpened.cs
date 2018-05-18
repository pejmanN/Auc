using System;
using Framework.Core.Events;

namespace AuctionManagement.Domain.Contracts.Auctions.Events
{
    public class AuctionOpened : DomainEvent
    {
        public long Id { get; private set; }
        public DateTime EndDateTime { get; private set; }
        public long ProductId { get; private set; }
        public long SellerId { get; private set; }
        public long StartingPrice { get; private set; }

        public AuctionOpened(long id, DateTime endDateTime, long productId, long sellerId, long startingPrice)
        {
            Id = id;
            EndDateTime = endDateTime;
            ProductId = productId;
            SellerId = sellerId;
            StartingPrice = startingPrice;
        }
    }
}

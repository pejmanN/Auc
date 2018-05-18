using System;
using Framework.Core.Events;

namespace AuctionManagement.Domain.Contracts.Auctions.Events
{
    public class BidPlacedOnAuction : DomainEvent
    {
        public long  AuctionId { get; private set; }
        public long BidderId { get; private set; }
        public long Amount { get; private set; }
        public DateTime OfferDateTime { get; private set; }

        public BidPlacedOnAuction(long auctionId, long bidderId, long amount, DateTime offerDateTime)
        {
            AuctionId = auctionId;
            BidderId = bidderId;
            Amount = amount;
            OfferDateTime = offerDateTime;
        }
    }
}
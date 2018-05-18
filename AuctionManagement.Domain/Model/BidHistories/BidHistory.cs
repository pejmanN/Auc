using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuctionManagement.Domain.Model.Auctions;
using AuctionManagement.Domain.Model.Shared;
using Framework.Core.Events;
using Framework.Domain;

namespace AuctionManagement.Domain.Model.BidHistories
{
    public class BidHistory : EntityBase<Guid>, IAggregateRoot
    {
        public AuctionId AuctionId { get; private set; }
        public long BidderId { get; private set; }
        public Money Offer { get; private set; }
        public DateTime CreateDateTime { get; private set; }

        public BidHistory(AuctionId auctionId, long bidderId, Money offer, DateTime createDateTime)
        {
            this.Id = Guid.NewGuid();
            this.AuctionId = auctionId;
            this.BidderId = bidderId;
            this.Offer = offer;
            this.CreateDateTime = createDateTime;
        }

        public IEventPublisher Publisher { get; set; }
    }
}

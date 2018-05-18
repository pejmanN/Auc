using System;
using AuctionManagement.Domain.Model.Shared;
using Framework.Core;
using Framework.Domain;

namespace AuctionManagement.Domain.Model.Auctions
{
    public class Bid : ValueObjectBase
    {
        public long BidderId { get;private set; }
        public Money OfferedAmount { get; private set; }
        public DateTime CreateDateTime { get; private set; }

        protected Bid() { }
        public Bid(long bidderId, Money offeredAmount)
        {
            BidderId = bidderId;
            OfferedAmount = offeredAmount;
            CreateDateTime = DateTime.Now;
        }

        public override bool Equals(object obj)
        {
            var bid = obj as Bid;
            if (bid == null) return false;

            return new EqualsBuilder()
                .Append(this.OfferedAmount, bid.OfferedAmount)
                .Append(this.BidderId, bid.BidderId)
                .Append(this.CreateDateTime, bid.CreateDateTime)
                .IsEquals();
        }

        public override int GetHashCode()
        {
            return new HashCodeBuilder()
                        .Append(this.BidderId)
                        .Append(this.OfferedAmount)
                        .Append(this.CreateDateTime)
                        .ToHashCode();
        }
    }
}
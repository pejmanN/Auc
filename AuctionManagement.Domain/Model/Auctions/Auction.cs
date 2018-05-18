using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuctionManagement.Domain.Contracts.Auctions.Events;
using AuctionManagement.Domain.Model.Participant;
using AuctionManagement.Domain.Model.Shared;
using AuctionManagement.Domain.Services;
using Framework.Core.Events;
using Framework.Domain;

namespace AuctionManagement.Domain.Model.Auctions
{
    public class Auction : AggregateRootBase<AuctionId>
    {
        public DateTime CreateDateTime { get;private set; }
        public DateTime EndDateTime { get; private set; }
        public long ProductId { get; private set; }
        public Participant Seller { get; private set; }
        public Money StartingPrice { get; private set; }
        public Bid WinningBid { get; private set; }

        protected Auction() {  }
        public Auction(AuctionId id, DateTime endDateTime, long productId, 
            Participant participant, Money startingPrice, IAuctionService service, IEventPublisher publisher) : base(publisher)
        {
            

            if (endDateTime <= DateTime.Now) throw new Exception();
            if (startingPrice.Amount <= 0) throw  new Exception();
            if (service.HasAnyOpenAuction(participant.Id)) throw new Exception();
            if (!participant.IsActive) throw  new Exception();

            this.Id = id;
            this.EndDateTime = endDateTime;
            this.CreateDateTime = DateTime.Now;
            this.ProductId = productId;
            this.Seller = participant;
            this.StartingPrice = startingPrice;

            Publish(new AuctionOpened(this.Id.DbId,this.EndDateTime, this.ProductId,this.Seller.Id,this.StartingPrice.Amount));
        }

        public void PlaceBid(Bid bid)
        {
            if (bid == null) throw new ArgumentNullException(nameof(bid));
            if (!IsAuctionOpen()) throw  new Exception();
            if (IsBidderSameAsSeller(bid)) throw  new Exception();
            if (!IsAmountValid(bid)) throw  new Exception();

            this.WinningBid = bid;

            Publish(new BidPlacedOnAuction(this.Id.DbId,bid.BidderId,bid.OfferedAmount.Amount,bid.CreateDateTime));
        }

        private bool IsAmountValid(Bid bid)
        {
            var maxPrice = GetMaxPrice();
            return maxPrice <= bid.OfferedAmount;
        }
        private Money GetMaxPrice()
        {
            var maxPrice = this.StartingPrice;
            if (WinningBid != null)
                maxPrice = this.WinningBid.OfferedAmount;
            return maxPrice;
        }
        private bool IsBidderSameAsSeller(Bid bid)
        {
            return this.Seller.Id == bid.BidderId;
        }

        private bool IsAuctionOpen()
        {
            return this.EndDateTime > DateTime.Now;
        }
    }
}

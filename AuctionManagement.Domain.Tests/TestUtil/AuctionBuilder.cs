using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuctionManagement.Domain.Model.Auctions;
using AuctionManagement.Domain.Model.Shared;
using AuctionManagement.Domain.Services;
using AuctionManagement.Domain.Tests.Stubs;

namespace AuctionManagement.Domain.Tests.TestUtil
{
    public class AuctionBuilder
    {
        private AuctionId _auctionId;
        private DateTime _endDateTime;
        private long _price;
        private Participant _seller;
        private long _productId;
        private IAuctionService _service;

        public AuctionBuilder()
        {
            this._price = 1000;
            this._auctionId = new AuctionId(1);
            this._endDateTime = DateTime.Now.AddYears(1);
            this._seller = new Participant(1,true);
            this._service = new FakeAuctionService(false);
        }
        public AuctionBuilder WithId(AuctionId id)
        {
            this._auctionId = id;
            return this;
        }

        public AuctionBuilder WithEndDate(DateTime dateTime)
        {
            this._endDateTime = dateTime;
            return this;
        }

        public AuctionBuilder WithStartingPrice(long price)
        {
            this._price = price;
            return this;
        }
        public AuctionBuilder WithSeller(long id)
        {
            this._seller = new Participant(id,true);
            return this;
        }
        public AuctionBuilder WithProduct(long id)
        {
            this._productId = id;
            return this;
        }

        public AuctionBuilder WithAuctionServiceReturningValue(bool value)
        {
            this._service = new FakeAuctionService(value);
            return this;
        }
        public Auction Build()
        {
            return new Auction(_auctionId, _endDateTime, _productId, this._seller,
                new Money(_price,"USD"), _service, new FakePublisher());
        }

        public static implicit operator Auction(AuctionBuilder builder)
        {
            return builder.Build();
        }

      
    }
}

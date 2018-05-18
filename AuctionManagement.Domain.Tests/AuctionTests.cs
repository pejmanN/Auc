using System;
using System.Linq;
using AuctionManagement.Domain.Contracts.Auctions.Events;
using AuctionManagement.Domain.Model.Auctions;
using AuctionManagement.Domain.Model.Shared;
using AuctionManagement.Domain.Tests.TestUtil;
using FluentAssertions;
using Xunit;

namespace AuctionManagement.Domain.Tests
{
    public class AuctionTests
    {
        [Fact]
        public void Auction_cant_be_start_with_zero_starting_price()
        {
            var builder = new AuctionBuilder().WithStartingPrice(0);
            Assert.Throws<Exception>(() =>
            {
                var auction = builder.Build();
            });
        }

        [Fact]
        public void Auction_cant_be_start_with_past_end_date()
        {
            var pastDate = DateTime.Now.AddYears(-1);
            var builder = new AuctionBuilder().WithEndDate(pastDate);

            Assert.Throws<Exception>(() =>
            {
                var auction = builder.Build();
            });
        }

        [Fact]
        public void Bid_should_be_greater_than_starting_price_on_first_bid()
        {
            Auction auction = new AuctionBuilder().WithStartingPrice(1000);
            var bid = new Bid(2, new Money(1200, "USD"));
            auction.PlaceBid(bid);
            Assert.Equal(auction.WinningBid,bid);
        }

        [Fact]
        public void Bid_should_be_greater_than_winning_bid_when_not_first_bid()
        {
            Auction auction = new AuctionBuilder().WithStartingPrice(1000);
            var bid = new Bid(2, new Money(1200, "USD"));
            auction.PlaceBid(bid);

            var secondBid = new Bid(2, new Money(1300, "USD"));
            auction.PlaceBid(secondBid);

            Assert.Equal(auction.WinningBid, secondBid);
        }

        [Fact]
        public void Seller_cant_place_bid_on_his_auction()
        {
            Auction auction = new AuctionBuilder().WithSeller(1);
            var bid = new Bid(1, new Money(1200, "USD"));

            Assert.Throws<Exception>(() =>
            {
                auction.PlaceBid(bid);
            });
        }

        [Fact]
        public void When_seller_already_has_open_auction_should_throw_exception()
        {
            var builder = new AuctionBuilder().WithAuctionServiceReturningValue(true);

            Assert.Throws<Exception>(() =>
            {
                var auction = builder.Build();
            });
        }

        [Fact]
        public void Constructing_auction_should_publish_AuctionOpenedEvent()
        {
            var builder = new AuctionBuilder();
            var auction = builder.Build();

            var events = auction.UncommittedEvents;

            events.Should().HaveCount(2);
            events.First().Should().BeOfType<AuctionOpened>();
            //TODO: assert auctionOpened properties
        }
    }
}

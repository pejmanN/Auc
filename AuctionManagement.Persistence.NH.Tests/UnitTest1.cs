using System;
using System.Configuration;
using System.Transactions;
using AuctionManagement.Domain.Model.Auctions;
using AuctionManagement.Domain.Model.Shared;
using AuctionManagement.Domain.Tests.Stubs;
using AuctionManagement.Domain.Tests.TestUtil;
using AuctionManagement.Persistence.NH.Mappings;
using AuctionManagement.Persistence.NH.Repositories;
using Framework.NH;
using Xunit;

namespace AuctionManagement.Persistence.NH.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Create_should_save_auction()
        {
            //using (var scope = new TransactionScope())
            //{
                var connectionString = "Data Source=.;Initial Catalog=EA_AuctionDB;Integrated Security=True";

                var factory = SessionFactoryBuilder.CreateByConnectionString(connectionString, typeof(AuctionMapping).Assembly);
                var session = factory.OpenSession();

                var repository = new AuctionRepository(session,new FakePublisher());
                //var id = repository.GetNextId();
                //var auction = new AuctionBuilder().WithId(id).WithProduct(1).WithSeller(2).Build();
                //auction.PlaceBid(new Bid(1,new Money(auction.StartingPrice.Amount + 10000,"USD")));

                //session.BeginTransaction();
                //repository.Add(auction);
                //session.Transaction.Commit();

                //session.Clear();
                var fetchAuction = repository.GetById(new AuctionId(23));

                //TODO: assert fetch Auction :)
            //}

        }
    }
}

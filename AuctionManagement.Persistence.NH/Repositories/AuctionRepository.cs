using System;
using System.Collections.Generic;
using System.Linq;
using AuctionManagement.Domain.Model.Auctions;
using Framework.Core.Events;
using Framework.NH;
using NHibernate;
using NHibernate.Linq;

namespace AuctionManagement.Persistence.NH.Repositories
{
    public class AuctionRepository  : BaseNHRepository<AuctionId,Auction>, IAuctionRepository
    {
        public AuctionRepository(ISession session, IEventPublisher publisher):base(session,publisher)
        {
        }

        public AuctionId GetNextId()
        {
            var value =  Session.NextSequenceValue("Auctions_Seq");
            return new AuctionId(value);
        }

        public bool HasOpenAuction(long sellerId)
        {
            return false;
            //return  _session.Query<Auction>().Any(a => a.SellerId == sellerId && a.)
        }

        public Auction GetById(AuctionId id)
        {
            return base.LoadAggregate(id);
        }

        public void Add(Auction auction)
        {
            Session.Save(auction);
        }
    }
}

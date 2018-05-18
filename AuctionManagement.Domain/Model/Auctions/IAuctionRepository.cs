using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Core;

namespace AuctionManagement.Domain.Model.Auctions
{
    public interface IAuctionRepository : IRepository
    {
        Auction GetById(AuctionId id);
        void Add(Auction auction);
        AuctionId GetNextId();
        bool HasOpenAuction(long sellerId);
    }
}

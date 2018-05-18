using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuctionManagement.Domain.Services;

namespace AuctionManagement.Domain.Model.Auctions
{
    public class AuctionService : IAuctionService
    {
        private readonly IAuctionRepository _repository;
        public AuctionService(IAuctionRepository repository)
        {
            this._repository = repository;
        }

        public bool HasAnyOpenAuction(long sellerId)
        {
            //Any logic that corresponds to validation 
            return _repository.HasOpenAuction(sellerId);
        }
    }
}

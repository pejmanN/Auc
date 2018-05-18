using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuctionManagement.Interface.Facade.Contracts.Auctions.Dto;
using AuctionManagement.Interface.Facade.Contracts.Auctions.Services;
using AuctionManagement.QueryModel;

namespace AuctionManagement.Interface.Facade.Query
{
    public class AuctionQueryFacade : IAuctionQueryFacade
    {
        private readonly QueryModelDb _queryModel;
        public AuctionQueryFacade(QueryModelDb queryModel)
        {
            _queryModel = queryModel;
        }
        public List<AuctionDTO> GetAll()
        {
            var data = _queryModel.Auctions.AsNoTracking().ToList();
            return data.Select(a => new AuctionDTO()
            {
                Id = a.Id,
                EndDateTime = a.EndDateTime,
                WinnerBidAmount = a.WinningBid_Amount,
                WinnerId = a.WinningBid_BidderId
            }).ToList();
        }
    }
}

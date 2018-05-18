using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using AuctionManagement.Interface.Facade.Contracts;
using AuctionManagement.Interface.Facade.Contracts.Auctions;
using AuctionManagement.Interface.Facade.Contracts.Auctions.Commands;
using AuctionManagement.Interface.Facade.Contracts.Auctions.Dto;
using AuctionManagement.Interface.Facade.Contracts.Auctions.Services;
using Framework.Application;
using Framework.Core.Events;

namespace AuctionManagement.Interface.RestApi
{
    public class AuctionsController : ApiController
    {
        //TODO: segregate controllers for memory usage effiency :)
        private readonly IAuctionFacadeService _facade;
        private readonly IAuctionQueryFacade _queryFacade;
        public AuctionsController(IAuctionFacadeService facade, IAuctionQueryFacade queryFacade)
        {
            _facade = facade;
            _queryFacade = queryFacade;
        }

        public List<AuctionDTO> Get()
        {
            return _queryFacade.GetAll();
        }

        public long Post(CreateAuctionCommand command)
        {
            return this._facade.Create(command);
        }

        public void Put(PlaceBidOnAuctionCommand command)
        {
            this._facade.PlaceBid(command);
        }
    }
}

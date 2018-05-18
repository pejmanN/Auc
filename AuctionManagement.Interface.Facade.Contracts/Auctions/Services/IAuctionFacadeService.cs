using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuctionManagement.Interface.Facade.Contracts.Auctions.Commands;
using Framework.Core;

namespace AuctionManagement.Interface.Facade.Contracts.Auctions.Services
{
    public interface IAuctionFacadeService : IFacadeService
    {
        long Create(CreateAuctionCommand command);
        void PlaceBid(PlaceBidOnAuctionCommand command);
    }
}

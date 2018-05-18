using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuctionManagement.Interface.Facade.Contracts.Auctions.Dto;
using Framework.Core;

namespace AuctionManagement.Interface.Facade.Contracts.Auctions.Services
{
    public interface IAuctionQueryFacade : IFacadeService
    {
        List<AuctionDTO> GetAll();
    }
}

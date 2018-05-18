using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionManagement.Domain.Services
{
    public interface IAuctionService
    {
        bool HasAnyOpenAuction(long sellerId);
    }
}

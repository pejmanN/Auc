using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuctionManagement.Domain.Services;

namespace AuctionManagement.Domain.Tests.Stubs
{
    public class FakeAuctionService : IAuctionService
    {
        private readonly bool _returnValue;
        public FakeAuctionService(bool returnValue)
        {
            _returnValue = returnValue;
        }
        public bool HasAnyOpenAuction(long sellerId)
        {
            return _returnValue;
        }
    }
}

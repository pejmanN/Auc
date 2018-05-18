using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionManagement.Interface.Facade.Contracts.BidHistory
{
    public class CreateBidHistoryCommand 
    {
        public long AuctionId { get; set; }
        public long BidderId { get;  set; }
        public long OfferedAmount { get;  set; }
        public DateTime CreateDateTime { get;  set; }

    }
}

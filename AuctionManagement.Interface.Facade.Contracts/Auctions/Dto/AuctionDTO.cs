using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionManagement.Interface.Facade.Contracts.Auctions.Dto
{
    public class AuctionDTO
    {
        public long Id { get; set; }
        public DateTime EndDateTime { get; set; }
        public long? WinnerId { get; set; }
        public long? WinnerBidAmount { get; set; }
    }
}

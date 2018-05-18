using System;

namespace AuctionManagement.Interface.Facade.Contracts.Auctions.Commands
{
    public class CreateAuctionCommand
    {
        public DateTime EndDateTime { get; set; }
        public long StartingPrice { get; set; }
        public long ProductId { get; set; }
        public long SellerId { get; set; }
    }
}

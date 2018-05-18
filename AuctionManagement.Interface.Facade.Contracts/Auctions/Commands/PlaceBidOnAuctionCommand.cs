namespace AuctionManagement.Interface.Facade.Contracts
{
    public class PlaceBidOnAuctionCommand
    {
        public long AuctionId { get; set; }
        public long BidderId { get; set; }
        public long Amount { get; set; }
    }
}
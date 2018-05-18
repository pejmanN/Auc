namespace AuctionManagement.QueryModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Auction
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }

        public DateTime CreateDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        public long ProductId { get; set; }

        public long SellerId { get; set; }

        public long StartingPrice_Amount { get; set; }

        [Required]
        [StringLength(3)]
        public string StartingPrice_Currency { get; set; }

        public long? WinningBid_BidderId { get; set; }

        public long? WinningBid_Amount { get; set; }

        [StringLength(3)]
        public string WinningBid_Currency { get; set; }

        public DateTime? WinningBid_CreateDateTime { get; set; }
    }
}

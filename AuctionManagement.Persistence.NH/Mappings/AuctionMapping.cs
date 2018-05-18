using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuctionManagement.Domain.Model.Auctions;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace AuctionManagement.Persistence.NH.Mappings
{
    public class AuctionMapping : ClassMapping<Auction>
    {
        public AuctionMapping()
        {
            Table("Auctions");
            ComponentAsId(a=>a.Id, z =>
            {
                z.Property(a=>a.DbId, a=>a.Column("Id"));
            });
            Lazy(false);
            Component(a=>a.StartingPrice, a =>
            {
                a.Property(z=>z.Amount, z=>z.Column("StartingPrice_Amount"));
                a.Property(z=>z.Currency, z=>z.Column("StartingPrice_Currency"));
            });

            Property(a=>a.CreateDateTime);
            Property(a=>a.EndDateTime);
            Property(a=>a.ProductId);
            //Property(a=>a.SellerId);
            Component(a => a.Seller, a =>
            {
                a.Property(z => z.Id, z => z.Column("SellerId"));
            });

            Component(a => a.WinningBid, a =>
            {
                a.Property(z => z.CreateDateTime, z => z.Column("WinningBid_CreateDateTime"));
                a.Property(z => z.BidderId, z => z.Column("WinningBid_BidderId"));
                a.Component(z => z.OfferedAmount, cmp =>
                {
                    cmp.Property(z => z.Amount, z => z.Column("WinningBid_Amount"));
                    cmp.Property(z => z.Currency, z => z.Column("WinningBid_Currency"));
                });
            });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace AuctionManagement.DatabaseMigrations
{
    [Migration(1)]
    public class _01_InitialAuction : Migration
    {
        public override void Up()
        {
            Create.Table("Auctions")
                .WithColumn("Id").AsInt64().PrimaryKey()
                .WithColumn("CreateDateTime").AsDateTime().NotNullable()
                .WithColumn("EndDateTime").AsDateTime().NotNullable()
                .WithColumn("ProductId").AsInt64().NotNullable()
                .WithColumn("SellerId").AsInt64().NotNullable()
                .WithColumn("StartingPrice_Amount").AsInt64().NotNullable()
                .WithColumn("StartingPrice_Currency").AsString(3).NotNullable()
                .WithColumn("WinningBid_BidderId").AsInt64().Nullable()
                .WithColumn("WinningBid_Amount").AsInt64().Nullable()
                .WithColumn("WinningBid_Currency").AsString(3).Nullable()
                .WithColumn("WinningBid_CreateDateTime").AsDateTime().Nullable();

            Create.Sequence("Auctions_Seq").Cache(50).StartWith(1).IncrementBy(1).MinValue(1);
        }

        public override void Down()
        {
            Delete.Table("Auctions");
            Delete.Sequence("Auctions_Seq");
        }
    }
}

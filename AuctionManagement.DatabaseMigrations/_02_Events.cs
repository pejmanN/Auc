using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace AuctionManagement.DatabaseMigrations
{
    [Migration(2)]
    public class _02_Events : Migration
    {
        public override void Up()
        {
            Create.Table("Events")
                .WithColumn("Id").AsGuid().NotNullable()
                .WithColumn("EventType").AsString(int.MaxValue).NotNullable()
                .WithColumn("SerializedContent").AsString(int.MaxValue).NotNullable()
                .WithColumn("CreateDateTime").AsDateTime().NotNullable()
                .WithColumn("IsProcessed").AsBoolean().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("Events");
        }
    }
}

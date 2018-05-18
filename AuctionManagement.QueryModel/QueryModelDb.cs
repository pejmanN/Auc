using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace AuctionManagement.QueryModel
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public class QueryModelDb : DbContext
    {
        static QueryModelDb()
        {
            Database.SetInitializer<QueryModelDb>(null);
        }
        public QueryModelDb(IDbConnection connection)
            : base(connection as SqlConnection,false)
        {
            this.Configuration.AutoDetectChangesEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Auction> Auctions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

        public override int SaveChanges()
        {
            throw  new NotSupportedException();
        }

        public override Task<int> SaveChangesAsync()
        {
            throw  new NotSupportedException();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            throw  new NotSupportedException();
        }
    }
}

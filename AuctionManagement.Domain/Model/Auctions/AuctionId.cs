using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Domain;

namespace AuctionManagement.Domain.Model.Auctions
{
    public class AuctionId : ValueObjectBase
    {
        public long DbId { get;private set; }
        protected AuctionId() { }
        public AuctionId(long dbId)
        {
            DbId = dbId;
        }

    }
}

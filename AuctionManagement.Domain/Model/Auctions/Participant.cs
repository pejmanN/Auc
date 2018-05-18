using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Core;
using Framework.Domain;

namespace AuctionManagement.Domain.Model.Auctions
{
    public class Participant : ValueObjectBase
    {
        //not a real ID as entityId just a value from another BC
        public long Id { get; private set; }
        public bool IsActive { get;private set; }

        protected Participant(){}
        public Participant(long id, bool isActive)
        {
            Id = id;
            IsActive = isActive;
        }
    }
}

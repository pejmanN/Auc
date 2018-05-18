using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Domain;

namespace AuctionManagement.Domain.Model.Participant
{
    public class ParticipantId : ValueObjectBase
    {
        public long DbId { get; private set; }
        protected ParticipantId(){}
        public ParticipantId(long dbId)
        {
            DbId = dbId;
        }

    }
}

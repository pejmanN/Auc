using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyManagement.Domain.Parties.States
{
    public abstract class PartyState
    {
        public virtual PartyState Revise()
        {
            throw  new NotSupportedException();
        }
        public virtual PartyState Confirm()
        {
            throw new NotSupportedException();
        }

        public virtual PartyState Reject()
        {
            throw new NotSupportedException();
        }
    }
}

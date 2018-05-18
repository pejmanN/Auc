using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Core;
using PartyManagement.Domain.Parties;

namespace PartyManagement.Domain
{
    public interface IPartyRepository : IRepository
    {
        Party GetById(PartyId id);
    }
}

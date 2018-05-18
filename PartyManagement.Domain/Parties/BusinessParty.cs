using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Core.Events;

namespace PartyManagement.Domain.Parties
{
    public class BusinessParty : Party
    {
        public string CompanyName { get; private set; }
        public string CeoName { get; private set; }
        public override string Fullname => CompanyName;

        public BusinessParty(PartyId id, string companyName, string ceoName, IEventPublisher publisher)
            : base(id, publisher)
        {
            this.CompanyName = companyName;
            this.CeoName = ceoName;
        }

      
    }
}

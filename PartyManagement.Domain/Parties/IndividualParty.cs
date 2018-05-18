using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Core.Events;

namespace PartyManagement.Domain.Parties
{
    public class IndividualParty : Party
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string SocialSecurityNumber { get; set; }
        public override string Fullname => $"{Firstname} {Lastname}";

        public IndividualParty(PartyId id, string firstname, string lastname, 
            string ssn,IEventPublisher publisher) : base(id, publisher)
        {
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.SocialSecurityNumber = ssn;
        }

    }
}

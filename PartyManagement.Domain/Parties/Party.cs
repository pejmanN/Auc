using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Core.Events;
using Framework.Domain;
using PartyManagement.Domain.Parties.States;

namespace PartyManagement.Domain.Parties
{
    public abstract class Party : EntityBase<PartyId>, IAggregateRoot
    {
        private readonly IList<Address> _addresses;
        public ReadOnlyCollection<Address> Addresses => new ReadOnlyCollection<Address>(_addresses);

        public PartyState State { get; private set; }
        public abstract string Fullname { get; }
        protected Party(PartyId id, IEventPublisher publisher)
        {
            this.Publisher = publisher;

            this.Id = id;
            this._addresses = new List<Address>();
            this.State = new WaitingForActivationState();
        }
        public void AssignAddress(List<Address> addressList)
        {
            this._addresses.UpdateValueObject(addressList);
        }

        public void Confirm()
        {
            this.State = State.Confirm();
        }

        public void Reject()
        {
            this.State = State.Reject();
        }

        public void Revise()
        {
            this.State = State.Revise();
        }

        public IEventPublisher Publisher { get; set; }
    }
}

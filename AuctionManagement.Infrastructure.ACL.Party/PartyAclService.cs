using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuctionManagement.Domain.Model.Auctions;
using AuctionManagement.Domain.Services;
using PartyManagement.Domain;
using PartyManagement.Domain.Parties;
using PartyManagement.Domain.Parties.States;

namespace AuctionManagement.Infrastructure.ACL.Party
{
    public class PartyAclService : IParticipantService
    {
        //private readonly IPartyRepository _repository;
        //public PartyAclService(IPartyRepository repository)
        //{
        //    this._repository = repository;
        //}

        public Participant GetById(long id)
        {
            //ACL helps me to seperate two BCs whenever i want without changing the domain
            //var party = _repository.GetById(new PartyId(id));
            //var isConfirm = party.State is ConfirmedState;
            return new Participant(id,true);
        }
    }
}

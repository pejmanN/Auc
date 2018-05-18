using System;
using System.Collections.Generic;
using AuctionManagement.Domain.Tests.Stubs;
using PartyManagement.Domain.Parties;
using PartyManagement.Domain.Parties.States;
using Xunit;

namespace PartyManagement.Domain.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void TestMethod1()
        {
            //var party = new BusinessParty(new PartyId(1), "Pegah", "Pejman Nazraz", new FakePublisher());
            //var address = new List<Address>()
            //{
            //    new Address(AddressType.HeadQuarter,"Tehran - No 5","1"),
            //    new Address(AddressType.Office,"Tehran - No 6","2"),
            //    new Address(AddressType.Home,"Tehran - No 7","2"),
            //};
            //party.AssignAddress(address);

            //var newAddresses = new List<Address>()
            //{
            //    new Address(AddressType.HeadQuarter,"Tehran - No 5","1"),
            //    new Address(AddressType.Office,"Shomal - Pelak 1","30215485"),
            //};
            //party.AssignAddress(newAddresses);
        }

        [Fact]
        public void Party_should_be_constructed_in_waitingForActive_state()
        {
            var party = new IndividualParty(new PartyId(1),"X","Y","10",new FakePublisher());
            Assert.IsType<WaitingForActivationState>(party.State);
        }
    }
}

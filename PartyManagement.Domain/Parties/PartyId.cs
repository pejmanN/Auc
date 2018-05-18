using Framework.Domain;

namespace PartyManagement.Domain.Parties
{
    public class PartyId : ValueObjectBase
    {
        public long DbId { get; private set; }
        public PartyId(long id)
        {
            this.DbId = id;
        }
    }
}
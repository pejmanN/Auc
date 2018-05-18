using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Core;
using Framework.Domain;

namespace PartyManagement.Domain.Parties
{
    public class Address : ValueObjectBase
    {
        public AddressType Type { get; private set; }
        public string Description { get; private set; }
        public string PostalCode { get; private set; }
        public Address(AddressType type, string description, string postalCode)
        {
            Type = type;
            Description = description;
            PostalCode = postalCode;
        }

        public override bool Equals(object obj)
        {
            var otherAddress = obj as Address;
            if (otherAddress == null) return false;
            return new EqualsBuilder()
                        .Append(this.Type, otherAddress.Type)
                        .Append(this.Description, otherAddress.Description)
                        .Append(this.PostalCode, otherAddress.PostalCode)
                        .IsEquals();
        }

        public override int GetHashCode()
        {
            return new HashCodeBuilder()
                .Append(this.Type)
                .Append(this.Description)
                .Append(this.PostalCode)
                .ToHashCode();
        }
    }
}

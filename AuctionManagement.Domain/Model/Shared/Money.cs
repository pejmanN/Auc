using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Core;
using Framework.Domain;

namespace AuctionManagement.Domain.Model.Shared
{
    public class Money : ValueObjectBase
    {
        public long Amount { get; private set; }
        public string Currency { get; private set; }

        protected Money() { }
        public Money(long amount, string currency)
        {
            Amount = amount;
            Currency = currency.ToUpper();
        }

        public override bool Equals(object obj)
        {
            var money = obj as Money;
            if (money == null) return false;
            return new EqualsBuilder()
                        .Append(this.Amount , money.Amount)
                        .Append(this.Currency, money.Currency)
                        .IsEquals();
        }

        public override int GetHashCode()
        {
            return new HashCodeBuilder()
                .Append(this.Amount)
                .Append(this.Currency)
                .ToHashCode();
        }

        public static bool operator ==(Money money1, Money money2)
        {
            long? x = money2?.Amount;
            if (x == null) return false;

            return money1.Amount == money2.Amount && money1.Currency == money2.Currency;
        }

        public static bool operator <=(Money money1, Money money2)
        {
            return money1 != null && money1.Amount <= money2.Amount;
        }

        public static bool operator >=(Money money1, Money money2)
        {
            return money1 != null && money1.Amount >= money2.Amount;
        }

        public static bool operator !=(Money money1, Money money2)
        {
            return !(money1 == money2);
        }
    }
}

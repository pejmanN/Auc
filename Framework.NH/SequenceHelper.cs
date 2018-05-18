using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;

namespace Framework.NH
{
    public static class SequenceHelper
    {
        public static long NextSequenceValue(this ISession session, string sequenceName)
        {
            return session.CreateSQLQuery($"SELECT NEXT VALUE FOR {sequenceName}")
                          .UniqueResult<long>();
        }
    }
}

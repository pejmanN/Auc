using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Core;
using NHibernate;

namespace Framework.NH
{
    public class NHUnitOfWork : IUnitOfWork
    {
        private readonly ISession _session;
        public NHUnitOfWork(ISession session)
        {
            this._session = session;
        }

        public void Begin()
        {
            _session.BeginTransaction(IsolationLevel.ReadCommitted);
        }

        public void Commit()
        {
            _session.Transaction.Commit();
        }

        public void Rollback()
        {
            _session.Transaction.Rollback();
        }
    }
}

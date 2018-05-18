using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Core;

namespace Framework.Application
{
    public class TransactionCommandHandlerDecorator<T> : ICommandHandler<T> where T : class
    {
        private readonly ICommandHandler<T> _targetHandler;
        private readonly IUnitOfWork _unitOfWork;

        public TransactionCommandHandlerDecorator(ICommandHandler<T> targetHandler,
            IUnitOfWork unitOfWork)
        {
            this._targetHandler = targetHandler;
            _unitOfWork = unitOfWork;
        }

        public void Handle(T command)
        {
            _unitOfWork.Begin();
            try
            {
                _targetHandler.Handle(command);
                _unitOfWork.Commit();
            }
            catch (Exception e)
            {
                _unitOfWork.Rollback();
                throw;
            }
        }
    }
}

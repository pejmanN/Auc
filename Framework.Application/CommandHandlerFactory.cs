using Framework.Core;

namespace Framework.Application
{
    public class CommandHandlerFactory
    {
        public static ICommandHandler<T> CreateHandler<T>() where T : class
        {
            return ServiceLocator.Current.Resolve<TransactionCommandHandlerDecorator<T>>();
        }
    }
}
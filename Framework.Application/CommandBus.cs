using Framework.Core;

namespace Framework.Application
{
    public class CommandBus : ICommandBus
    {
        public void Dispatch<T>(T command) where T : class
        {
            ICommandHandler<T> handler = null;
            try
            {
                handler = CommandHandlerFactory.CreateHandler<T>();
                handler.Handle(command);
            }
            finally
            {
                if (handler != null)
                    ServiceLocator.Current.Release(handler);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Application
{
    public interface ICommandHandler<T> where T : class
    {
        void Handle(T command);
    }
}

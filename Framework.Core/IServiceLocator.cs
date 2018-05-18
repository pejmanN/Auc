using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Core
{
    public interface IServiceLocator
    {
        T Resolve<T>();
        void Release(object obj);
    }

    public static class ServiceLocator
    {
        public static IServiceLocator Current { get; private set; }
        public static void Set(IServiceLocator locator)
        {
            Debug.Assert(Current == null);
//#if DEBUG
//            if (Current != null) throw new Exception(); 
//#endif

            Current = locator;
        }
    }
}

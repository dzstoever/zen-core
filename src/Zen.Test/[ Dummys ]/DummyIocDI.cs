using System;
using Zen.Ioc;

namespace Zen.Test
{
    public class DummyIocDI : IocDI
    {
        public void Initialize()
        {
            throw new NotImplementedException();
        }

        public T Resolve<T>()
        {
            throw new NotImplementedException();
        }

        public object Resolve(Type type)
        {
            throw new NotImplementedException();
        }

        public void Release(object o)
        {
            throw new NotImplementedException();
        }


        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}

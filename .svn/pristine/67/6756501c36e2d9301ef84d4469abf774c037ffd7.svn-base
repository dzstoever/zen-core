using System;
using System.Collections.Generic;

namespace Zen.Ioc
{
    /// <summary>
    /// Supplies singleton instances of types using System.Activator 
    /// </summary>
    /// <remarks>default implementation</remarks>
    public class SingletonDI : IocDI
    {
        // note: not part of the interface
        // added for instances where we just want to add some quick and simple DI, like testing
        public static void Register<T>(object impl)
        {
            if (instances == null) instances = new Dictionary<Type, object>();
            var type = typeof(T);
            instances.Add(type, impl);
        }

        private static IDictionary<Type, object> instances; 


        public void Initialize()
        {
            instances = new Dictionary<Type, object>(); 
        }

        public T Resolve<T>()
        {
            var type = typeof(T);
            try
            {
                if (!instances.ContainsKey(type))
                    instances.Add(type, Activator.CreateInstance<T>());

                return (T)instances[type];
            }
            catch (Exception ex)
            { throw new DependencyException("Unable to instantiate: " + type, ex);
            }            
        }

        public object Resolve(Type type)
        {
            try
            {
                if (!instances.ContainsKey(type))
                    instances.Add(type, Activator.CreateInstance(type));

                return instances[type];
            }
            catch (Exception ex)
            { throw new DependencyException("Unable to instantiate: " + type, ex);
            }             
        }

        public void Release(object o)
        {
            instances.Remove(o.GetType());
        }

        public void Dispose()
        {
            foreach (var instance in instances)
                Release(instance);            
        }
    }
}
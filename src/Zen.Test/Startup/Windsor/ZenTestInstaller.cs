using System.Diagnostics;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using NHibernate;
using Zen.Data;
using Zen.Log;
using ILoggerFactory = Zen.Log.ILoggerFactory;

namespace Zen.Test.Startup.Windsor
{
    public class ZenTestInstaller : IWindsorInstaller
    {
        //public static ISessionFactory SessionFactory { get; set; }

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            // Loggers can always be obtained from the Aspects, but this adds the ability to get a Logger/LoggerFactory 
            // from the IoC/DI container and any other registered components with a Logger/LoggerFactory dependency 
            // will have it injected automatically
            container.Register(Component.For<ILoggerFactory>()
                                   .ImplementedBy<Log4netLoggerFactory>()
                                   .LifestyleSingleton());
            container.Register(Component.For<ILogger>()
                                   .ImplementedBy<Log4netLogger>()
                                   .LifestyleSingleton());

            // This must be set prior to calling DaoConfigurator.Configure();
            container.Register(Component.For<IDbCnnFactory>()
                                   .ImplementedBy<TestSqlCnnFactory>()
                                   .LifestyleSingleton());
            
            // Configure from TestSqlCnnFactory
            NHConfigurator.Configure();
            Debug.Assert(NHConfigurator.SessionFactory != null, "DaoConfigurator.SessionFactory != null");
            container.Register(Component.For<ISessionFactory>()
                                   .Instance(NHConfigurator.SessionFactory)
                                   .LifestyleSingleton());
            container.Register(Component.For<IGenericDao>()
                                   .ImplementedBy<NHibernateDao>()
                                   .LifestyleSingleton());

        }
    }
}
using System.Diagnostics;
using FluentAssertions;
using Xbehave;
using Xunit;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using NHibernate;
using Zen.Data;
using Zen.Ioc;
using Zen.Log;
using Zen.Test.Maps;

namespace Zen.Test
{
    /// <summary>
    /// Use this class to create the ZenTestDb for use by the other tests
    /// It will also map the domain entities and provide examples of a 
    /// dao configuration along with logging and dependency injection 
    /// using the StartupFixture 
    /// </summary>
    /// <remarks>
    /// When testing RDBMS  we generally want to test only three things:
    ///  *  1) Properties are persisted 
    ///  *  2) Cascade works as expected
    ///  *  3) Queries return the correct result 
    /// 
    /// Why test using a Mock Database instead of Mock Objects?
    ///     In order to do all of those, we generally have to talk to a real database, 
    ///     trying to fake any of those at this level is futile and going to be very complicated.
    ///     We could use a standard in memory database(SQLite) in order to get very speedy tests.
    /// </remarks>
    /// <see cref="http://ayende.com/blog/3983/nhibernate-unit-testing"/>
    public class ZenTestDbFacts : UseStartupFixture
    {
        public ZenTestDbFacts()
        {
            _di = Aspects.GetIocDI();
            _log = _di.Resolve<ILogger>();
            _dao = _di.Resolve<IGenericDao>();
        }

        ~ZenTestDbFacts()
        {
            if(_dao!=null) _dao.Dispose();
            if(_di!=null) _di.Dispose();            
        }

        private readonly IocDI _di;
        private readonly ILogger _log;
        private readonly IGenericDao _dao;

        const int ExpectedMapCount = 66;

        // Note: The following tests demonstrate different ways to configure data access.
        //       We are skipping them because they would affect all subsequent tests.
        //       Our _dao is being configured in the Bootstrapper.DaoConfigStartupTask...

        [Fact(Skip ="affects data access for all subsequent tests")]
        public void ConfigureFromIDbCnnFactory()
        {
            NHConfigurator.Configure(new ZenTestDbContext()); 
            var cnnFactory = _di.Resolve<IDbContext>();
            _log.Info(cnnFactory.ToString());
            
            var sessionFactory = _di.Resolve<ISessionFactory>();
            sessionFactory.Should().NotBeNull();
            var session = _dao.StartUnitOfWork();
            session.Should().NotBeNull();

            NHConfigurator.SessionFactoryImpl.Settings.SessionFactoryName.Should().BeNull();
            NHConfigurator.SessionFactoryImpl.GetAllClassMetadata().Count.Should().Be(ExpectedMapCount);
        }
        
        [Fact(Skip ="affects data access for all subsequent tests")]
        public void ConfigureFromAppConfig()
        {
            NHConfigurator.Configure("", typeof(PersonMap).Assembly, null);

            var sessionFactory = _di.Resolve<ISessionFactory>();
            sessionFactory.Should().NotBeNull();
            var session = _dao.StartUnitOfWork();
            session.Should().NotBeNull();

            NHConfigurator.SessionFactoryImpl.Settings.SessionFactoryName.Should().Be("AppConfig.SessionFactory");
            NHConfigurator.SessionFactoryImpl.GetAllClassMetadata().Count.Should().Be(ExpectedMapCount);
        }
        
        [Fact(Skip ="affects data access for all subsequent tests")]
        public void ConfigureFromCfgXml()
        {
            NHConfigurator.Configure("nh.cfg.xml", typeof(PersonMap).Assembly, null);//this will add the embedded .hbms
            var windsorDI = Aspects.GetIocDI() as WindsorDI;
            Debug.Assert(windsorDI != null, "windsorDI != null");
            var container = windsorDI.Container as IWindsorContainer;
            Debug.Assert(container != null, "container != null");
            container.Register(Component.For<ISessionFactory>()
                                   .Instance(NHConfigurator.SessionFactory)
                                   .LifestyleSingleton()
                                   .IsDefault().Named("SessionFactoryOverride"));

            var sessionFactory = _di.Resolve<ISessionFactory>();
            sessionFactory.Should().NotBeNull();

            var session = _dao.StartUnitOfWork();
            session.Should().NotBeNull();

            NHConfigurator.SessionFactoryImpl.Settings.SessionFactoryName.Should().Be("Test.SessionFactory");
            NHConfigurator.SessionFactoryImpl.GetAllClassMetadata().Count.Should().Be(ExpectedMapCount);            
        }


        [Fact]
        public void DropDbSchema()
        {
            NHConfigurator.DropDbSchema();
            
        }

        [Fact]
        public void CreateDbSchema()
        {
            NHConfigurator.CreateDbSchema();
                        
        }

        
    }
}
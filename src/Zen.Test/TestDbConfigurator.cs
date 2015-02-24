using FluentAssertions;
using NHibernate;
using Xbehave;
using Xunit;
using Zen.Data;
using Zen.Ioc;
using Zen.Log;

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
    /// We could use a standard in memory database(SQLite) in order to get very speedy tests.
    /// </remarks>
    /// <see cref="http://ayende.com/blog/3983/nhibernate-unit-testing"/>
    public class TestDbConfigurator : UseStartupFixture
    {
        public TestDbConfigurator()
        {
            _di = Aspects.GetIocDI();
            _log = _di.Resolve<ILogger>();
            _dao = _di.Resolve<IGenericDao>();
        }

        ~TestDbConfigurator()
        {
            if(_dao!=null) _dao.Dispose();
            if(_di!=null) _di.Dispose();            
        }

        private readonly IocDI _di;
        private readonly ILogger _log;
        private readonly IGenericDao _dao;


        [Fact(Skip = "affects db access for all subsequent tests")]
        public void ConfigureFromIDbCnnFactory()
        {
            NHConfigurator.XmlConfigFileName = null;
            NHConfigurator.Configure(); 

            var cnnFactory = _di.Resolve<IDbCnnFactory>();
            _log.Info(cnnFactory.ToString());
            
            var sessionFactory = _di.Resolve<ISessionFactory>();
            sessionFactory.Should().NotBeNull();

            var session = _dao.StartUnitOfWork();
            session.Should().NotBeNull();

            NHConfigurator.SessionFactoryImpl.Settings.SessionFactoryName
                .Should().BeNull();
        }

        [Fact(Skip ="affects db access for all subsequent tests")]
        public void ConfigureFromAppConfig()
        {
            NHConfigurator.XmlConfigFileName = "";
            NHConfigurator.Configure();

            var cnnFactory = _di.Resolve<IDbCnnFactory>();
            _log.Info(cnnFactory.ToString());

            var sessionFactory = _di.Resolve<ISessionFactory>();
            sessionFactory.Should().NotBeNull();

            var session = _dao.StartUnitOfWork();
            session.Should().NotBeNull();

            NHConfigurator.SessionFactoryImpl.Settings.SessionFactoryName
                .Should().Be("AppConfig.SessionFactory");
        }

        [Fact]
        public void ConfigureFromCfgXml()
        {
            NHConfigurator.XmlConfigFileName = "nh.cfg.xml";
            NHConfigurator.Configure();

            var cnnFactory = _di.Resolve<IDbCnnFactory>();
            _log.Info(cnnFactory.ToString());

            var sessionFactory = _di.Resolve<ISessionFactory>();
            sessionFactory.Should().NotBeNull();

            var session = _dao.StartUnitOfWork();
            session.Should().NotBeNull();

            NHConfigurator.SessionFactoryImpl.Settings.SessionFactoryName
                .Should().Be("Test.SessionFactory");
        }

        

        [Fact]
        public void CreateDbSchema()
        {
            "Given some arranged preconditions".Given(() =>
            {
                

            });
            "When the code under test runs".When(() =>
            {                
                //Log.InfoFormat("do something with it");

            });
            "Then the actual results meet expectations".Then(() =>
            {                
                //Log.InfoFormat("is everything as it should be");
            });
            
        }

        
    }
}
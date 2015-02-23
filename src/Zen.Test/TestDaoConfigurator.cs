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
    public class TestDaoConfigurator : UseStartupFixture
    {
        public TestDaoConfigurator()
        {
            _di = Aspects.GetIocDI();
            _log = _di.Resolve<ILogger>();
            _dao = _di.Resolve<IGenericDao>();

            var cnnFactory = _di.Resolve<IDbCnnFactory>();
            _log.Info(cnnFactory.ToString());            
        }

        ~TestDaoConfigurator()
        {
            if(_dao!=null) _dao.Dispose();
            if(_di!=null) _di.Dispose();            
        }

        private readonly IocDI _di;
        private readonly ILogger _log;
        private readonly IGenericDao _dao;

        //[Trait("name", "value")]
        
        [Fact]
        public void ConfigureFromAppConfig()
        {
            DaoConfigurator.CreateDb(true);

            
        }

        [Fact]
        public void ConfigureFromHibernateCfgXml()
        {

        }

        [Fact]
        public void ConfigureFromIDbCnnFactory()
        {
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
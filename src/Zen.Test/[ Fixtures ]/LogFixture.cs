using System;
using Xunit;
using Zen.Log;

namespace Zen.Test
{

    /// <summary>
    /// Base class for other scenarios providing a static Log member
    /// </summary>
    public class UseLogFixture : IUseFixture<LogFixture>
    {
        public void SetFixture(LogFixture data) { }
        protected static readonly ILogger Log = Aspects.GetLogger();
    }

    /// <summary>
    /// Configures logging for any typical test class.
    /// Allows us to use the same logging configuration for any test classes while calling .Configure() only once.
    /// </summary>    
    public class LogFixture : IDisposable
    {
        static LogFixture()
        {
            Log4netConfigurator.DefaultPattern = "|%-5level| %message %n";
            Log4netConfigurator.RootLogLevel = LogLevel.Debug;
            Log4netConfigurator.TurnAppender(Appenders.Debug, OnOff.On);
            Log4netConfigurator.TurnAppender(Appenders.Console, OnOff.On);
            Log4netConfigurator.Configure();

            Aspects.GetLogger("LogFixture").DebugFormat("Logging configured."); //this message should be in the debug window (only once)
        }

        public void Dispose()
        { }
    }

    

}


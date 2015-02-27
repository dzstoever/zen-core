using System;
using Bootstrap.Extensions.StartupTasks;
using Zen.Log;

namespace Zen.Startup.Bootstrap
{
    public class LogConfigStartupTask : IStartupTask
    {
        /// <summary>
        /// Configure default logging options which are applied every time we startup...
        /// </summary>
        private static void ConfigureLogging()
        {
            // This would stop the default console and debug outputs
            // Log4netConfigurator.RootLogLevel = LogLevel.Off;

            // make all these appenders available to Zen.* loggers
            var appenders = new[] { Appenders.EventLog, Appenders.File, Appenders.Rtb, Appenders.Smtp, Appenders.Sql, Appenders.Trace };
            Log4netConfigurator.SetLoggerAppenders("Zen", LogLevel.All, appenders);
            //Log4netConfigurator.TurnAppenders(appenders, OnOff.On);
            // turn appenders on/off by default
            Log4netConfigurator.TurnAppender(Appenders.File,     OnOff.On);
            Log4netConfigurator.TurnAppender(Appenders.Rtb,      OnOff.On);            
            Log4netConfigurator.TurnAppender(Appenders.EventLog, OnOff.Off);
            Log4netConfigurator.TurnAppender(Appenders.Smtp,     OnOff.Off);
            Log4netConfigurator.TurnAppender(Appenders.Sql,      OnOff.Off);
            Log4netConfigurator.TurnAppender(Appenders.Trace,    OnOff.Off);
            
            // stop this external logger by default, in case we are using NHibernate
            Log4netConfigurator.TurnLoggerOff("NHibernate");

            // any LoggingExceptions will go to these appenders (as long as the appenders are turned on)
            Log4netConfigurator.ErrorHandlerAppenders = new[] { Appenders.Debug, Appenders.Console, Appenders.File, Appenders.Rtb };
            Log4netConfigurator.ErrorHandler = typeof(LoggingErrorHandler);

            Log4netConfigurator.Configure();
        }

        public void Run()
        {
            ConfigureLogging();
        }

        public void Reset()
        {
            ConfigureLogging(); // reconfigure to undo anything that changed...
        }

        //nested class
        public class LoggingErrorHandler : Log4netErrorHandler, log4net.Core.IErrorHandler
        {
            public void Error(string message, Exception exc, log4net.Core.ErrorCode errorCode)
            { base.Error(message, exc, errorCode); }
        }

    }

    
}
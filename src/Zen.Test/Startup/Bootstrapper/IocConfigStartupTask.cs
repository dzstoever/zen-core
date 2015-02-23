using System;
using System.Diagnostics;
using Bootstrap.Extensions.StartupTasks;
using Zen.Ioc;
using Zen.Log;

namespace Zen.Test.Startup.Bootstrapper
{
    public class IocConfigStartupTask : IStartupTask
    {
        private static void ConfigureWindsorDI()
        {
            // use all the WindsorInstallers from this assembly
            WindsorDI.ConfigureFromAssembly = typeof(StartupFixture).Assembly;

            var windsorDI = Aspects.GetIocDI() as WindsorDI;
            Debug.Assert(windsorDI != null, "windsorDI != null");
            try
            {// run all installers
                windsorDI.Initialize();
            }
            catch (Exception ex)
            {
                "IocDI.Initialize() failed.{0}{1}".LogMe(LogLevel.Fatal, Environment.NewLine, ex.FullMessage());
                throw new ConfigException("Could not initialize dependency injection.", ex);
            }
        }

        public void Run()
        {
            ConfigureWindsorDI();
        }

        public void Reset()
        {
            ConfigureWindsorDI();
        }
    }
}
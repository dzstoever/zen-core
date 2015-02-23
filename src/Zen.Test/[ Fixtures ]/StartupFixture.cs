using System;
using System.Reflection;
using Bootstrap;
using Bootstrap.Extensions.StartupTasks;
using Xunit;
using Zen.Test.Startup.Bootstrapper;

namespace Zen.Test
{
    /// <summary>
    /// Base class for other scenarios providing a startup implementation
    /// </summary>
    public class UseStartupFixture : IUseFixture<StartupFixture>
    {
        public void SetFixture(StartupFixture data) { }        
    }

    /// <summary>
    /// Configures bootstrapper for any typical test class.
    /// Allows us to use the same StartupTasks, etc. for any test classes.
    /// </summary>    
    public class StartupFixture : IDisposable
    {
        // In a typical application, this would be the code run in App_Startup
        // For web applications, we would need to account for IIS recycles...
        static StartupFixture()
        {            
            // Bootstrapper will scan the list of extensions that were declared and will invoke the run method of each one 
            // in the order that they were declared. This is important to note if, for example you want your startup tasks 
            // to use an initialized container, make sure to declare the container extension before the startup task extension. 
            Bootstrapper.IncludingOnly.Assembly(Assembly.GetExecutingAssembly())//.AndAssembly(typeof())
                        .With.StartupTasks().UsingThisExecutionOrder(o => o
                            .First<LogConfigStartupTask>()
                            //.Then<DaoConfigStartupTask>()
                            .Then<IocConfigStartupTask>())
                        //.And.Windsor().WithContainer(windsorDI.Container)
                        //    .UsingAutoRegistration()// automatically register all types that implement an interface of the same name
                        //.And.AutoMapper()
                        .Start();


            //try
            //{ var king = windsorDI.Resolve<IViewFactory>(); }// 2. resolve the king and all his subjects
            //catch (Exception ex)
            //{
            //    "IocDI.Resolve<> failed.{0}{1}".LogMe(LogLevel.Fatal, Environment.NewLine, ex.FullMessage());
            //    throw new DependencyException("Could not resolve the king.", ex);
            //}
        }

        //private static IocDI DI = null;

        public void Dispose()
        {
            var di = Aspects.GetIocDI();
            if (di != null) di.Dispose();// In a typical application, dispose container on App_Exit 
        }
    }

}
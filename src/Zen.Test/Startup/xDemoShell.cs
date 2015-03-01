using System;
using System.Reflection;
using Bootstrap;
using Bootstrap.Extensions.StartupTasks;
using Zen.Ioc;

namespace Zen.Startup
{
    public class DemoShell : IStartup
    {
        public void Startup()
        {
            Bootstrapper.IncludingOnly.Assembly(Assembly.GetExecutingAssembly())
                        .With.StartupTasks() //.And.AutoMapper()
                        .Start();

            WindsorDI.ConfigureFromInstallers = new object[]
            { 
                //new LogInstaller(),
                //new SvcInstaller(),
                //new DemoInstaller() 
            };
            try 
            {
                Aspects.GetIocDI().Initialize();// run all installer(s) 
            }
            catch (Exception ex)
            {
                throw new ConfigException("Failed to initialize dependency injection.", ex);
            }

        }
        
    }
}

    


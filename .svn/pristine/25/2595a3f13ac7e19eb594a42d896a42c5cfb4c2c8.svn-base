using System;
using System.Configuration;
using System.Reflection;
using Castle.Facilities.WcfIntegration;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Zen.Log;
using Zen.Svcs;


namespace Zen.Startup.Windsor
{
    // Note: to get a self host to use the WindsorServiceHostFactory...
    // WindsorContainer container = new WindsorContainer("windsor.xml");
    // WindsorServiceHostFactory.RegisterContainer(container.Kernel);
    // but a custom host factory can not be set on the WcfSvcHost.exe...

    public class SvcInstaller : IWindsorInstaller
    {

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            var svcAssemblyName = ConfigurationManager.AppSettings["svcAssembly"];
            if (svcAssemblyName == null) throw  
                new ConfigException("key = 'svcAssembly' must be set in <appSettings> value = name of the assembly containing the wcf service implementations.");
            
            var svcAssembly = Assembly.Load(svcAssemblyName);
            if(svcAssembly == null) throw new ConfigException("The svcAssembly[{0}] could not be loaded.".FormatWith(svcAssemblyName));
            
            container.Register( AllTypes.FromAssembly(svcAssembly)
                                        .BasedOn<IRemoteFacade>()//.Pick()...Note: Find all the classes in the assembly with an interface and add them to the container
                                        .WithService.DefaultInterfaces()                                         
                                        .Configure(c => c.LifeStyle.PerWcfOperation())
                              );
        }
    }
    /* standard server-side component registration
       Component.For<IService1>()
                .ImplementedBy<Service1>()
                .AsWcfService(new DefaultServiceModel(WcfEndpoint
                                                        .BoundTo(new WSHttpBinding()))
                                                        .AddBaseAddresses("http://localhost:1234/Service1")
                                                        .PublishMetadata(m => m.EnableHttpGet())));
    */
}
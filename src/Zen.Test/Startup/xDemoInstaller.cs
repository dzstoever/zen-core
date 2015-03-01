using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
//using Zen.Examples;
//using Zen.Examples.Demos;

namespace Zen.Startup.Windsor
{
    public class DemoInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            //container.Register(Component.For<IKingOfExamples>()
            //                            .ImplementedBy<KingJames>()
            //                            .LifestyleSingleton());
                        
            //container.Register(Component.For<LogDemo>()
            //                            .ImplementedBy<LogDemo>());
            //container.Register(Component.For<WcfDemo>()
            //                            .ImplementedBy<WcfDemo>());
            //container.Register(Component.For<WebDemo>()
            //                            .ImplementedBy<WebDemo>());
            //container.Register(Component.For<WpfDemo>()
            //                            .ImplementedBy<WpfDemo>());

            //container.Register(Component.For<DbDemo>()
            //                            .ImplementedBy<DbDemo>());
        }
    }
}

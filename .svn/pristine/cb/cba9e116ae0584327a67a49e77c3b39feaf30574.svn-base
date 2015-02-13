using System;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;

namespace Zen.Svcs
{
    public class ZenHostFactory : ServiceHostFactory
    {
        public static string BuildEndpointsDescription(ServiceHostBase svcHost)
        {
            var sb = new StringBuilder();
            foreach (var endpoint in svcHost.Description.Endpoints)
            {
                sb.AppendFormat("----------{0}", Environment.NewLine);
                sb.AppendFormat(" Endpoint {0}{1}", endpoint.Name, Environment.NewLine);
                sb.AppendFormat("----------{0}", Environment.NewLine);
                //sb.AppendFormat("    Name: {0}{1}", endpoint.Name, Environment.NewLine);
                sb.AppendFormat(" Address: {0}{1}", endpoint.Address, Environment.NewLine);
                sb.AppendFormat(" Binding: {0}{1}", endpoint.Binding.Name, Environment.NewLine);
                sb.AppendFormat("Contract: {0}{1}", endpoint.Contract.Name, Environment.NewLine);
            }
            return sb.ToString();            
        }


        public ZenHostFactory()
        {
            var di = Aspects.GetIocDI();

        }        

        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            
            return new ServiceHost(serviceType, baseAddresses);
        }

        //var hostFactoryImpl = di.Resolve<ServiceHostFactory>();

    }
}
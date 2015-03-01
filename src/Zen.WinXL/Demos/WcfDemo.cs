using System;
using System.ServiceModel;
using System.Threading.Tasks;
using Zen.Log;
using Zen.Svcs;

namespace Zen.WinXL.Demos
{
    public class WcfDemo : IRunnable
    {
        public ILogger Logger { get; set; }

        public void RunHost()
        {
            var baseAddresses = new[] {
                //"http://127.0.0.1:1010/Zen/SecureSignon",
                "net.tcp://localhost:2020/Zen" };
                //"net.pipe://localhost/Zen/SecureSignon" };
            var baseUris = new Uri[baseAddresses.Length];
            for (var i = 0; i < baseAddresses.Length; i++)
            {
                baseUris[i] = new Uri(baseAddresses[i]);
            }

            //var svcType = typeof(SecureSignonSvc);
            using (var svcHost = new ServiceHost(typeof(SecureSignonSvc), baseUris))
            {
                svcHost.AddServiceEndpoint(typeof(ISecureSignon), new NetTcpBinding(), "SecureSignon");

                //Todo: set other service model configuration optons emphatically...
                
                svcHost.Open();
                Logger.InfoFormat("The [{0}] service is online.", "SecureSignon");
                Logger.Info(ZenHostFactory.BuildEndpointsDescription(svcHost));

                Task.Factory.StartNew(() =>
                        Run(), TaskScheduler.Default);
                        //.ContinueWith(TaskExceptionHandler, TaskContinuationOptions.OnlyOnFaulted);
                
                //svcHost.Close();
            }
        }


        public void Run()
        {
            var address = new EndpointAddress("net.tcp://localhost:5150/EIS/SecureCredentialServer");//"http://localhost:1080/Zen/RemoteFacade");
            var binding = new NetTcpBinding(); //WSHttpBinding(); // BasicHttpBinding();
            var channelFactory = new ChannelFactory<ISecureSignon>(binding);
            var proxy = channelFactory.CreateChannel(address);

            string token;
            if (proxy != null)
            {
                var tokenRequest = new TokenRequest() 
                {
                    RequestId = Guid.NewGuid().ToString(),
                    ClientTag = "YesterdayUponTheStairIMetAGirlWhoWasntThere"// Identifies the client so the service can issue an AccessToken
                };
                var tokenResponse = proxy.GetToken(tokenRequest);
                token = tokenResponse.AccessToken;
                Logger.Info(token);
                //Console.ReadLine();
            }
        }
    }
}

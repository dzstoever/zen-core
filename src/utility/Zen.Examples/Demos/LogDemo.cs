using System;
using System.ServiceModel;
using System.Windows.Forms;
using Zen.Examples.Logging;
using Zen.Log;

namespace Zen.Examples.Demos
{
    public class LogDemo : IRunnable
    {
        public void Run()
        {
            // listen for messages from the WcfAppernder, and propogate...
            //var sh = new ServiceHost(typeof(WcfLogger));
            //foreach (var endpoint in WcfLogger.ServiceEndpoints)
            //    sh.AddServiceEndpoint(
            //        typeof(IWcfLogger), WcfLogger.GetBindingFromEndpoint(endpoint) , endpoint);                        
            //sh.Open();             
            
            Application.EnableVisualStyles();
            Application.Run(new Frogger { Text = "Logging Configurator" });
            
            //sh.Close();
        }
    }

    
}

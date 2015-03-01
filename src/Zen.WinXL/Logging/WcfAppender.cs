using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using log4net.Appender;
using log4net.Core;
using Zen.Log;

namespace Zen.WinXL.Logging
{
    public class WcfAppender : AppenderSkeleton
    {
        // instances of IWcfLogger that will hold channels to the wcf service(s)
        static readonly IList<IWcfLogger> WcfLoggerProxies = new List<IWcfLogger>();
        static WcfAppender()
        {
            // read base addresses from .config...
            foreach (var key in System.Configuration.ConfigurationManager.AppSettings.AllKeys.Where(key => key.Contains("BaseUri")))
                WcfLoggerProxies.Add(ChannelFactory<IWcfLogger>.CreateChannel(
                    WcfLogger.GetBindingFromEndpoint(System.Configuration.ConfigurationManager.AppSettings[key]), 
                    new EndpointAddress(new Uri(System.Configuration.ConfigurationManager.AppSettings[key]))));


            

            //WcfLoggerProxies.Add(ChannelFactory<IWcfLogger>.CreateChannel(
            //        new BasicHttpBinding(), new EndpointAddress(new Uri("http://hosted.transchart.net:1080/WcfLoggerSvc"))));
        }

        protected override void Append(LoggingEvent loggingEvent)
        {
            try
            {
                // send to wcf service(s), if any are listening...
                foreach (var proxy in WcfLoggerProxies)
                    proxy.NewExceptionMessage(
                        loggingEvent.LoggerName,
                        loggingEvent.Level.DisplayName,
                        loggingEvent.RenderedMessage,
                        loggingEvent.ExceptionObject);
            }
            catch (EndpointNotFoundException)
            {
                //???
                //MessageBox.Show(ex.FullMessage());
            }
            
        }
    }
    
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace Zen.Log
{
    [ServiceContract]
    public interface IWcfLogger
    {
        [OperationContract]
        void NewMessage(string message);

        [OperationContract]
        void NewLogMessage(string loggerName, string logLevel, string message);

        [OperationContract]
        void NewExceptionMessage(string loggerName, string logLevel, string message, Exception exception);
    }

    public class WcfLogger : IWcfLogger
    {
        public const string ServiceName = "WcfLoggerSvc";

        public static System.ServiceModel.Channels.Binding GetBindingFromEndpoint(string endpoint)
        {
            //System.ServiceModel.Channels.Binding binding;
            if (endpoint.StartsWith("https:")) return new WSHttpBinding();
            if (endpoint.StartsWith("http:")) return new BasicHttpBinding();
            if (endpoint.StartsWith("net.tcp:")) return new NetTcpBinding();
            if (endpoint.StartsWith("net.pipe:")) return new NetNamedPipeBinding();
            throw new ApplicationException("Invalid Service Endpoint! " + endpoint);
        }

        public static IEnumerable<string> ServiceEndpoints
        {
            get { return _baseAddresses.Select(b => b + (b.EndsWith("/") ? "" : "/") + ServiceName).ToList(); }
        }

        public static IEnumerable<string> BaseAddresses
        {
            set { _baseAddresses = value; }
        }
        static IEnumerable<string> _baseAddresses = new []
        {// default is to listen on these Uri's
            "http://127.0.0.1:1080/",
            "net.tcp://127.0.0.1:3949/",
            "net.pipe://localhost/"
        };

        

        public void NewMessage(string message)
        {
            // in this implementation we will get all messages from 
            // wcf appender and simply write them as debug messages
            var logger = Aspects.GetLoggerFactory().Create("Zen.Log.WcfLogger");
            logger.Info(message);
        }

        public void NewLogMessage(string loggerName, string logLevel, string message)
        {
            NewExceptionMessage(loggerName, logLevel, message, null);
        }

        public void NewExceptionMessage(string loggerName, string logLevel, string message, Exception exception)
        {
            // in this implementation we will get all messages from 
            // wcf appender and write them with thier metadata
            var logger = Aspects.GetLoggerFactory().Create(loggerName);
            switch (logLevel.ToUpper())
            {
                case "DEBUG":
                    logger.Debug(message);
                    break;
                case "INFO":
                    logger.Info(message);
                    break;
                case "WARN":
                    logger.Warn(message);
                    break;
                case "ERROR":
                    if (exception == null) logger.Error(message);
                    else logger.Error(message, exception);
                    break;
                case "FATAL":
                    if (exception == null) logger.Fatal(message);
                    else logger.Fatal(message, exception);
                    break;
                default:
                    logger.Info(message);
                    break;                
                    
            }
        }
    }
}

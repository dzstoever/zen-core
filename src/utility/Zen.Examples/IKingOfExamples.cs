using System;
using Zen.Examples.Demos;

namespace Zen.Examples
{
    public interface IKingOfExamples
    {
        IRunnable LogDemo { get; set; }
        IRunnable DbDemo { get; set; }        
        IRunnable WcfDemo { get; set; }
        IRunnable WebDemo { get; set; }
        IRunnable WpfDemo { get; set; }
    }
    
    public class KingJames : IKingOfExamples
    {
        public LogDemo LogDemoImpl { get; set; }
        public DbDemo DbDemoImpl { get; set; }
        public WcfDemo WcfDemoImpl { get; set; }
        public WebDemo WebDemoImpl { get; set; }
        public WpfDemo WpfDemoImpl { get; set; }
        
        public IRunnable LogDemo { get { return LogDemoImpl; } set { LogDemoImpl = value as LogDemo; } }
        public IRunnable DbDemo { get { return DbDemoImpl; } set { DbDemoImpl = value as DbDemo; } }
        public IRunnable WcfDemo { get { return WcfDemoImpl; } set { WcfDemoImpl = value as WcfDemo; } }
        public IRunnable WebDemo { get { return WebDemoImpl; } set { WebDemoImpl = value as WebDemo; } }
        public IRunnable WpfDemo { get { return WpfDemoImpl; } set { WpfDemoImpl = value as WpfDemo; } }
    }


    public class WebDemo : IRunnable
    {
        public void Run() { throw new NotImplementedException(); }
    }

    public class WpfDemo : IRunnable
    {
        public void Run() { throw new NotImplementedException(); }
    }


}

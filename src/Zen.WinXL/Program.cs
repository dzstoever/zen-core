using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Zen.Log;
using Zen.WinXL.Demos;
using Zen.WinXL.XmlControls;


namespace Zen.WinXL
{
    /// <summary>
    /// A short program to introduce some benefits of the Zen framework
    /// </summary>
    class Program
    {
        static IKingOfExamples King { get; set; }
        static ILogger Logger { get; set; }

        [STAThread]// run in STA so OLE calls can be made
        static void Main() 
        {   
            Console.Title = "Zen Demo";            
            try
            {
                // check for admin privaleges (needed to host wcf)
                //if (!new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator))
                //    throw new ApplicationException("This program must be run as an administrator!");

                // run the startup shell to configure everything
                //new DemoShell().Startup();
            }
            catch (ApplicationException ex)
            {
                Console.WriteLine(ex.FullMessage());
                ShowMenu(true);                 
                ReadMenuOption(true);
            }
            // use inversion of control to resolve the king and all his subjects
            using (var di = Aspects.GetIocDI())
            {
                Console.WriteLine("{0} Dependency Injector(DI) Type: {1} {0}\n",(char)1 , di.GetType());                
                try
                {
                    di.Initialize();
                    King = di.Resolve<IKingOfExamples>();
                    Logger = di.Resolve<ILogger>();                    
                    ShowIntro();
                    ShowMenu(false);
                    do 
                    {
                        try
                        { ReadMenuOption(false); }
                        catch (Exception ex)
                        { Aspects.GetLogger().Error(ex); }
                        
                    } while (true);
                }
                
                catch (Exception ex)
                { Aspects.GetLogger().Fatal(ex); }
                finally
                { ReadMenuOption(true); }
            } 

        }

        /// <summary>
        /// Displays a brief logging intro
        /// </summary>
        static void ShowIntro()
        {
            Log4netConfigurator.TurnAppender(Appenders.Console, OnOff.On, true);    // hello console!
            
            Logger.Fatal("Class level Logger came from DI");
            "Logger Name: {0}".FormatWith(Logger.Name).LogMe(LogLevel.Info);
            "Logger Type: {0}".FormatWith(Logger.GetType()).LogMe(LogLevel.Info);
            Logger = Aspects.GetLogger();
            "- You can get one from the provider,  ".LogMe(LogLevel.Debug);
            Logger = Aspects.GetLoggerFactory().Create(typeof(LogDemo));
            "  or you can get one from the factory.".LogMe(LogLevel.Debug);
            "- Just turn on/off the desired appenders".LogMe(LogLevel.Debug);
            "  to start or stop logging when needed.\n".LogMe(LogLevel.Debug);

            Log4netConfigurator.TurnAppender(Appenders.Console, OnOff.Off, true);   // good-bye console!
            
            Logger.Info("I will not be logged to the console, " +
                        "but I should be in the debug window");

            Log4netConfigurator.TurnAppender(Appenders.Console, OnOff.On, true);    // hello again!
            
            Logger.Fatal("Appenders (send messages to these based on severity)");
            "Console [{0}], Debug [{1}], EventLog [{2}], File [{3}], "
                .FormatWith(Log4netConfigurator.AppendersOnOff[Appenders.Console],
                            Log4netConfigurator.AppendersOnOff[Appenders.Debug],
                            Log4netConfigurator.AppendersOnOff[Appenders.EventLog],
                            Log4netConfigurator.AppendersOnOff[Appenders.File])
                 .LogMe(LogLevel.Info);
            "Rtb [{0}], Smtp [{1}], Sql [{2}], Trace [{3}]"
                .FormatWith(Log4netConfigurator.AppendersOnOff[Appenders.Rtb],
                            Log4netConfigurator.AppendersOnOff[Appenders.Smtp],
                            Log4netConfigurator.AppendersOnOff[Appenders.Sql],
                            Log4netConfigurator.AppendersOnOff[Appenders.Trace])
                .LogMe(LogLevel.Info);

            //Console.WriteLine("{0} Message Levels (severity) {0}", (char)1);
            //Log4netConfigurator.LogAllLevelMessages(Logger);

        }

        /// <summary>
        /// Displays the menu options
        /// </summary>
        /// <param name="exitOnly"></param>
        static void ShowMenu(bool exitOnly)
        {
            Console.WriteLine("");
            Aspects.GetLogger().Fatal("{0}".FormatWith((char)2)); //Choose a demo...
            if (!exitOnly)
            {
                Console.WriteLine("0 | app.config");
                Console.WriteLine("1 | Logging...");
                Console.WriteLine("2 | Database...");
                //Console.WriteLine("3 | ServiceHost...");
                //Console.WriteLine("4 | Wcf Demo");
                //Console.WriteLine("5 | Wpf Demo");
                //Console.WriteLine("6 | Web Demo");
            }
                Console.WriteLine("x | to exit.");
            Aspects.GetLogger().Fatal("{0}".FormatWith((char)2));
        }

        /// <summary>
        /// Reads the next key pressed and starts a new thread or task
        /// </summary>        
        static void ReadMenuOption(bool exitOnly)
        {
            ConsoleKeyInfo keyPressed;
            var menuOptions = new HashSet<char>() { '0','1', '2', '3', '4', '5', '6' };
            do
            {
                keyPressed = Console.ReadKey(true);
                if (keyPressed.KeyChar == 'X' || keyPressed.KeyChar == 'x') Environment.Exit(0);                
            }
            while (exitOnly || !menuOptions.Contains(keyPressed.KeyChar));
            Console.WriteLine("{0} {1}", keyPressed.KeyChar, (char)2);

            //var cancelToken = new CancellationToken();
            switch (keyPressed.KeyChar)
            {
                case '0':
                    Task.Factory.StartNew(() =>
                        XmlForm.ShowDialog(Assembly.GetEntryAssembly().Location + ".config"), new SingleThreadTaskScheduler())
                        .ContinueWith(TaskExceptionHandler, TaskContinuationOptions.OnlyOnFaulted);
                    break;
                case '1':
                    Task.Factory.StartNew(() => 
                        King.LogDemo.Run(), new SingleThreadTaskScheduler())
                        .ContinueWith(TaskExceptionHandler, TaskContinuationOptions.OnlyOnFaulted);
                    break;
                case '2':
                    Task.Factory.StartNew(() =>
                       King.DbDemo.Run(), new SingleThreadTaskScheduler())
                       .ContinueWith(TaskExceptionHandler, TaskContinuationOptions.OnlyOnFaulted);                    
                    break;
                case '3':
                    throw new NotImplementedException();
                    //Task.Factory.StartNew(() => 
                    //    King.WcfDemo.Run(), TaskScheduler.Default)
                    //    .ContinueWith(TaskExceptionHandler, TaskContinuationOptions.OnlyOnFaulted);
                    //break;
                case '4':
                    throw new NotImplementedException();
                    //Task.Factory.StartNew(() => 
                    //    King.WcfDemo.Run(), TaskScheduler.Default)
                    //    .ContinueWith(TaskExceptionHandler, TaskContinuationOptions.OnlyOnFaulted);
                    //break;
                case '5':
                    Task.Factory.StartNew(() =>
                        King.WpfDemo.Run(), TaskScheduler.Default)
                        .ContinueWith(TaskExceptionHandler, TaskContinuationOptions.OnlyOnFaulted);
                    break;
                case '6':
                    Task.Factory.StartNew(() =>
                        King.WebDemo.Run(), TaskScheduler.Default)
                        .ContinueWith(TaskExceptionHandler, TaskContinuationOptions.OnlyOnFaulted);
                    break;
            }
            //return null;
        }

        static void TaskExceptionHandler(Task task)
        {
            var aggEx = task.Exception;
            Aspects.GetLogger().Fatal(aggEx.FullMessage());
        }
        
    }

    
}

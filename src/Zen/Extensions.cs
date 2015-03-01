using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Zen.Log;

namespace Zen
{    
    public static class Extensions
    {

        /// <summary> 
        /// Returns "null", "empty string", or obj.ToString() for any object
        /// </summary>
        public static string ShowNullorEmptyString(this object obj)
        {
            if (obj == null) return "null";
            if (obj is string && (string)obj == "") return "empty string";
            return obj.ToString();
        }

        /// <summary>
        /// Logs a message using Aspects.GetLogger()
        /// </summary>
        public static void LogMe(this String str, LogLevel level, params object[] args)
        {
            if (level == LogLevel.Off) return;

            var log = Aspects.GetLogger();
            switch (level)
            {
                case LogLevel.Debug: log.DebugFormat(str, args);
                    break;
                case LogLevel.Info: log.InfoFormat(str, args);
                    break;
                case LogLevel.Warn: log.WarnFormat(str, args);
                    break;
                case LogLevel.Error: log.ErrorFormat(str, args);
                    break;
                case LogLevel.Fatal: log.Fatal(string.Format(str, args));
                    break;
                case LogLevel.All:
                    log.DebugFormat(str, args);
                    log.InfoFormat(str, args);
                    log.WarnFormat(str, args);
                    log.ErrorFormat(str, args);
                    log.Fatal(string.Format(str, args));
                    break;
            }
        }

        /// <summary>
        /// Replaces format items with string representations of the args
        /// </summary>
        public static string FormatWith(this String str, params object[] args)
        {
            return string.Format(str, args);
        }

        /// <summary>
        /// Converts a comma-seperated string into an enumerable collection of strings
        /// </summary>
        public static IEnumerable<string> CsvToList(this String listvals)
        {
            var list = new List<string>();
            if (string.IsNullOrEmpty(listvals)) return list;

            var vals = listvals.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            list.AddRange(vals.Select(val => val.Trim()));
            return list;
        }

        /// <remarks>
        /// Converts an enumerable collection of strings into a comma-seperated string
        /// </remarks>
        public static string ListToCsv(this IEnumerable<string> collection)
        {
            var list = collection.ToList();
            if (list.Count <= 0) return "";

            var sb = new StringBuilder(list[0]);
            list.RemoveAt(0);
            foreach (var val in list) sb.Append("," + val);
            return sb.ToString();
        }

        /// <summary>
        /// Combines the ex.Message with each inner exception message on a new line 
        /// </summary>
        public static string FullMessage(this Exception ex)
        {
            var fullMessage = ex.Message;
            var inner = ex.InnerException;
            while (inner != null)
            {
                fullMessage += Environment.NewLine + " * " + inner.Message;
                inner = inner.InnerException;
            }
            return fullMessage;
        }
                
        /// <summary>
        /// Gets the name of the process executable in the default application domain. 
        /// In other application domains, this is the first executable that was executed 
        /// by System.AppDomain.ExecuteAssembly(System.String).
        /// </summary>
        public static string GetEntryAssemblyName(this Assembly assembly)
        {
            return Assembly.GetEntryAssembly().GetName().Name; 
        }

        /// <summary>
        /// Gets a string representing the amount of time that has elapsed since the given time
        /// </summary>
        public static string GetElapsedTime(this DateTime dt, bool includeMs)
        {
            var elapsed = DateTime.Now.Subtract(dt).ToString();
            return !includeMs ? elapsed.Remove(elapsed.LastIndexOf('.')) : elapsed;
        }

        /// <summary>
        /// Creates and starts a System.Threading.Tasks.Task
        /// </summary>
        public static Task StartNew(this TaskFactory factory, Action action, TaskScheduler scheduler)
        {
            return factory.StartNew(action, factory.CancellationToken, factory.CreationOptions, scheduler);
        }

        /// <summary>
        /// Creates and starts a System.Threading.Tasks.Task{TResult}.
        /// </summary>        
        public static Task<T> StartNew<T>(this TaskFactory factory, Func<T> func, TaskScheduler scheduler)
        {
            return factory.StartNew(func, factory.CancellationToken, factory.CreationOptions, scheduler);
        }
        
        
    }
}

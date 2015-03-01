using System;

namespace Zen.Cmds
{
    public interface ICmd
    {
        
        /// <summary>
        ///   Holds exception details, if any
        /// </summary>
        Exception Exception { get; }

        
        /// <summary>
        ///   Runs command without exception handling
        /// </summary>
        void Run();

        /// <summary>
        ///   Runs command in a try-catch block
        /// </summary>
        /// <returns>false if an exception occurs</returns>
        bool TryRun();
        
    }

    /// <summary>
    ///   Derive from this base class and implement Run()...
    ///   The interface will handle everything else.
    /// </summary>
    /// <remarks>
    ///   All implementations can be cast as ICmd(s) and run as part of a CommandScript
    /// </remarks>
    public abstract class BaseCmd : ICmd
    {

        /// <summary>
        /// Holds exception details, if any
        /// </summary>
        public Exception Exception { get; private set; }

        /// <summary>
        /// Runs cmd in a try-catch block
        /// </summary>
        /// <returns>false if an exception occurs</returns>
        public bool TryRun()
        {
            try
            {
                Run();
                return true;
            }
            catch (Exception exc)
            {
                Exception = exc;
                return false;
            }
        }

        /// <summary>
        /// Runs cmd without exception handling
        /// </summary>
        public abstract void Run();

    }

}
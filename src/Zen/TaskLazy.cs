using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Zen
{
    /// <summary>
    /// Provides access to a value that will become available at some point in the future.
    /// </summary>
    /// <remarks>
    /// This type provides implicit conversions to T and Task<T> 
    /// The implicit conversion to T calls ValueOrDefault.
    /// </remarks>
    /// <typeparam name="T">
    /// The type of the value.
    /// </typeparam>
    public struct TaskLazy<T>
    {
        public static implicit operator T(TaskLazy<T> taskLazy)
        {
            return taskLazy.ValueOrDefault();
        }
        public static implicit operator Task<T>(TaskLazy<T> taskLazy)
        {
            return taskLazy.Task;
        }
        public static implicit operator TaskLazy<T>(Task<T> task)
        {
            return new TaskLazy<T>(task);
        }
        //public static implicit operator TaskLazy<T>(T value)
        //{
        //    return System.Threading.Tasks.Task.FromResult(value);
        //}


        /// <summary>
        /// Returns the Task which is used to retrieve the value of this TaskLazy<T>
        /// </summary>
        public Task<T> Task { get; private set; }

        /// <summary>
        /// Returns a value indicating whether the Value is available.
        /// </summary>
        public bool IsReady
        {
            get { return Task.IsCompleted && !Task.IsFaulted; }
        }

        /// <summary>
        /// Returns the Value or throws an exception if it is not yet available.
        /// </summary>        
        public T Value
        {
            get
            {
                if (!IsReady)
                    throw new InvalidOperationException("Cannot access Value before it is available.");

                return Task.Result;
            }
        }


        /// <summary>
        /// Creates a new TaskLazy<T> based on a constant value.
        /// </summary>
        /// <remarks>
        /// IsReady will be true.
        /// </remarks>
        //public TaskLazy(T value) : this(System.Threading.Tasks.Task.FromResult(value))
        //{ }

        /// <summary>
        /// Creates a new TaskLazy<T> based on a Func<T> which will be invoked in a new Task.
        /// </summary>
        /// <remarks>
        /// The function will run on TaskScheduler.Default.
        /// </remarks>
        //public TaskLazy(Func<T> func) : this(System.Threading.Tasks.Task.Run(func))
        //{ }
        
        /// <summary>
        /// Creates a new TaskLazy<T> based on a Task<T>
        /// </summary>
        /// <remarks>
        /// You can also directly assign a Task<T> to a TaskLazy<T> variable.
        /// </remarks>
        public TaskLazy(Task<T> task) : this()
        {
            Task = task;
        }


        /// <summary>
        /// Calls an Action in the current synchronization context after the Value has become available.
        /// </summary>
        /// <remarks>
        /// This method uses TaskScheduler.Current.
        /// </remarks>
        public Task WhenValueAvailable(Action action)
        {
            return WhenValueAvailable(t => action());
        }
        
        /// <summary>
        /// Calls an Action<T> in the current synchronization context after the Value has become available.
        /// </summary>
        /// <remarks>
        /// This method uses TaskScheduler.Current.
        /// </remarks>
        public Task WhenValueAvailable(Action<T> action)
        {
            Trace.Assert(SynchronizationContext.Current != null);

            return WhenValueAvailableAsync(action, TaskScheduler.FromCurrentSynchronizationContext());
        }

        /// <summary>
        /// Calls an Action<T> using a specified TaskScheduler after the Value has become available.
        /// </summary>        
        public Task WhenValueAvailableAsync(Action<T> action, TaskScheduler taskScheduler = null)
        {
            return Task.ContinueWith(task => action(task.Result), taskScheduler ?? TaskScheduler.Default);
        }

        /// <summary>
        /// Tries to retrieve the Value if it is available.
        /// </summary>
        /// <returns>
        /// true when IsReady otherwise false.
        /// </returns>
        public bool TryGetValue(out T result)
        {
            if (!IsReady)
            {
                result = default(T);
                return false;
            }

            result = Value;
            return true;
        }
        
        /// <summary>
        /// Returns Value if it is available or default(T) otherwise.
        /// </summary>
        public T ValueOrDefault(T def = default(T))
        {
            T result;
            if (!TryGetValue(out result))
                return def;

            return result;
        }

        /// <summary>
        /// Returns the value of a Func<T, T2> which receives Value as a paremeter or default(T) if the value is not available yet.
        /// </summary>
        /// <typeparam name="T2">
        /// The return value.
        /// </typeparam>
        /// <param name="func">
        /// The function to call when the value is available.
        /// </param>
        /// <param name="def">
        /// The value to return when the value is not available yet.
        /// </param>
        /// <example>
        /// <![CDATA[
        /// TaskLazy<DateTime> taskLazy = //...
        /// string value = taskLazy.ActionOrDefault(date => date.ToString(), "Loading...");
        /// ]]>
        /// </example>
        public T2 ActionOrDefault<T2>(Func<T, T2> func, T2 def = default(T2))
        {
            return !Task.IsCompleted ? def : func(Task.Result);
        }
    }
}
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Zen
{
    /// <summary>
    /// The SingleThreadTaskScheduler can be used like any other task scheduler: 
    /// When starting a new Task using Task.Factory.StartNew(…) or using task.ContinueWith(…), 
    /// the task scheduler to use is one of the possible arguments. 
    /// </summary>
    /// <example>
    /// <![CDATA[
    /// //For maximum convenience, the library also includes two extension methods which allow you to write:
    /// var taskScheduler = //...
    /// Task.Factory.StartNew(() => /*Do something*/, taskScheduler);
    /// //respectively:
    /// var result = await Task.Factory.StartNew(() => return /*Some value*/, taskScheduler);
    /// ]]>
    /// </example>
    public static class TaskFactoryExtensions
    {
        public static Task StartNew(this TaskFactory factory, Action action, TaskScheduler scheduler)
        {
            return factory.StartNew(action, factory.CancellationToken, factory.CreationOptions, scheduler);
        }
        public static Task<T> StartNew<T>(this TaskFactory factory, Func<T> func, TaskScheduler scheduler)
        {
            return factory.StartNew(func, factory.CancellationToken, factory.CreationOptions, scheduler);
        }
    }


    /// <summary>
    /// Represents a <see cref="TaskScheduler"/> which executes code on a dedicated, 
    /// single thread whose <see cref="ApartmentState"/> can be configured.
    /// </summary>
    /// <remarks>
    /// Use to perform operations on a non thread-safe library from a multi-threaded environment.
    /// </remarks>
    /// <see cref="http://www.journeyofcode.com/custom-taskscheduler-sta-threads/"/>
    public sealed class SingleThreadTaskScheduler : TaskScheduler, IDisposable
    {
        private readonly Thread _thread;
        private readonly CancellationTokenSource _cancellationToken;
        private readonly BlockingCollection<Task> _tasks;
        private readonly Action _initAction;

        public ApartmentState ApartmentState { get; private set; }
        public override int MaximumConcurrencyLevel { get { return 1; } }


        public SingleThreadTaskScheduler(ApartmentState apartmentState = ApartmentState.STA) : this(null, apartmentState)
        { }
        public SingleThreadTaskScheduler(Action initAction, ApartmentState apartmentState = ApartmentState.STA)
        {
            if (apartmentState != ApartmentState.MTA && apartmentState != ApartmentState.STA)
                throw new ArgumentException("apartementState");

            ApartmentState = apartmentState;
            _cancellationToken = new CancellationTokenSource();
            _tasks = new BlockingCollection<Task>();
            _initAction = initAction ?? (() => { });

            _thread = new Thread(this.ThreadStart);
            _thread.IsBackground = true;
            _thread.TrySetApartmentState(apartmentState);
            _thread.Start();
        }


        /// <summary>
        /// Waits until all scheduled Tasks have executed and then disposes this instance.
        /// </summary>
        /// <remarks>
        /// Calling this method will block execution. It should only be called once.
        /// </remarks>
        /// <exception cref="TaskSchedulerException">
        /// Thrown when this instance already has been disposed by calling either Wait() or Dispose().
        /// </exception>
        public void Wait()
        {
            if (this._cancellationToken.IsCancellationRequested)
                throw new TaskSchedulerException("Cannot wait after disposal.");

            this._tasks.CompleteAdding();
            this._thread.Join();

            this._cancellationToken.Cancel();
        }

        /// <summary>
        /// Disposes this instance by not accepting any further work and not executing previously scheduled tasks.
        /// </summary>
        /// <remarks>
        /// Call Wait() instead to finish all queued work. You do not need to call Dispose() after calling Wait().
        /// </remarks>
        public void Dispose()
        {
            if (this._cancellationToken.IsCancellationRequested)
                return;

            this._tasks.CompleteAdding();
            this._cancellationToken.Cancel();
        }

        protected override void QueueTask(Task task)
        {
            VerifyNotDisposed();
            
            _tasks.Add(task, this._cancellationToken.Token);
        }

        protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
        {
            VerifyNotDisposed();

            if (this._thread != Thread.CurrentThread)
                return false;
            if (this._cancellationToken.Token.IsCancellationRequested)
                return false;

            this.TryExecuteTask(task);
            return true;
        }

        protected override IEnumerable<Task> GetScheduledTasks()
        {
            this.VerifyNotDisposed();

            return this._tasks.ToArray();
        }


        private void ThreadStart()
        {
            try
            {
                var token = this._cancellationToken.Token;

                this._initAction();

                foreach (var task in this._tasks.GetConsumingEnumerable(token))
                    this.TryExecuteTask(task);
            }
            finally
            {
                this._tasks.Dispose();
            }
        }

        private void VerifyNotDisposed()
        {
            if (this._cancellationToken.IsCancellationRequested)
                throw new ObjectDisposedException(typeof(SingleThreadTaskScheduler).Name);
        }
    }


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
            get { return this.Task.IsCompleted && !this.Task.IsFaulted; }
        }

        /// <summary>
        /// Returns the Value or throws an exception if it is not yet available.
        /// </summary>        
        public T Value
        {
            get
            {
                if (!this.IsReady)
                    throw new InvalidOperationException("Cannot access Value before it is available.");

                return this.Task.Result;
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
            this.Task = task;
        }


        /// <summary>
        /// Calls an Action in the current synchronization context after the Value has become available.
        /// </summary>
        /// <remarks>
        /// This method uses TaskScheduler.Current.
        /// </remarks>
        public Task WhenValueAvailable(Action action)
        {
            return this.WhenValueAvailable(t => action());
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

            return this.WhenValueAvailableAsync(action, TaskScheduler.FromCurrentSynchronizationContext());
        }

        /// <summary>
        /// Calls an Action<T> using a specified TaskScheduler after the Value has become available.
        /// </summary>        
        public Task WhenValueAvailableAsync(Action<T> action, TaskScheduler taskScheduler = null)
        {
            return this.Task.ContinueWith(task => action(task.Result), taskScheduler ?? TaskScheduler.Default);
        }

        /// <summary>
        /// Tries to retrieve the Value if it is available.
        /// </summary>
        /// <returns>
        /// true when IsReady otherwise false.
        /// </returns>
        public bool TryGetValue(out T result)
        {
            if (!this.IsReady)
            {
                result = default(T);
                return false;
            }

            result = this.Value;
            return true;
        }
        
        /// <summary>
        /// Returns Value if it is available or default(T) otherwise.
        /// </summary>
        public T ValueOrDefault(T def = default(T))
        {
            T result;
            if (!this.TryGetValue(out result))
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
            if (!this.Task.IsCompleted)
                return def;

            return func(this.Task.Result);
        }
    }
}

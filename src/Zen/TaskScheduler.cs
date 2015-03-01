using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Zen
{    
    /// <summary>
    /// Represents a 'TaskScheduler' which executes code on a dedicated, single thread 
    /// whose 'ApartmentState' can be configured.
    /// </summary>
    /// <remarks>
    /// Use to perform operations on a non thread-safe library from a multi-threaded environment.
    /// The SingleThreadTaskScheduler can be used like any other task scheduler: 
    /// When starting a new Task using Task.Factory.StartNew(…) or using task.ContinueWith(…),
    /// the task scheduler to use is one of the possible arguments. 
    /// </remarks>
    /// <example>
    /// <![CDATA[
    /// // The library also includes two extension methods which allow you to write:
    /// var taskScheduler = Task.Factory.StartNew(() => /*Do something*/, taskScheduler);
    /// // -or-
    /// var result = await Task.Factory.StartNew(() => return /*Some value*/, taskScheduler);
    /// ]]>
    /// </example>
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

            _thread = new Thread(ThreadStart);
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
            if (_cancellationToken.IsCancellationRequested)
                throw new TaskSchedulerException("Cannot wait after disposal.");

            _tasks.CompleteAdding();
            _thread.Join();

            _cancellationToken.Cancel();
        }

        /// <summary>
        /// Disposes this instance by not accepting any further work and not executing previously scheduled tasks.
        /// </summary>
        /// <remarks>
        /// Call Wait() instead to finish all queued work. You do not need to call Dispose() after calling Wait().
        /// </remarks>
        public void Dispose()
        {
            if (_cancellationToken.IsCancellationRequested)
                return;

            _tasks.CompleteAdding();
            _cancellationToken.Cancel();
        }

        protected override void QueueTask(Task task)
        {
            VerifyNotDisposed();
            
            _tasks.Add(task, _cancellationToken.Token);
        }

        protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
        {
            VerifyNotDisposed();

            if (_thread != Thread.CurrentThread)
                return false;
            if (_cancellationToken.Token.IsCancellationRequested)
                return false;

            TryExecuteTask(task);
            return true;
        }

        protected override IEnumerable<Task> GetScheduledTasks()
        {
            VerifyNotDisposed();

            return _tasks.ToArray();
        }


        private void ThreadStart()
        {
            try
            {
                var token = _cancellationToken.Token;

                _initAction();

                foreach (var task in _tasks.GetConsumingEnumerable(token))
                    TryExecuteTask(task);
            }
            finally
            {
                _tasks.Dispose();
            }
        }

        private void VerifyNotDisposed()
        {
            if (_cancellationToken.IsCancellationRequested)
                throw new ObjectDisposedException(typeof(SingleThreadTaskScheduler).Name);
        }
    }
}

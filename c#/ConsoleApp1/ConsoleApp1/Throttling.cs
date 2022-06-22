using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class ThrottleingTest
    {
        public void Execute()
        {
            Console.WriteLine("Trottling result:");
            var trottledAction = new Throttler(300, (s) => Console.WriteLine(s));

            foreach (var s in new string[] { "a", "ab", "abc", "abcd", "abcde", "abcdef", "abcdefg", "abcdefgh", "abcdefghi" })
            {
                Thread.Sleep(100);
                trottledAction.Invoke(s);
            }

            /*-------------*/

            Console.WriteLine("Debouncing result:");
            var DebouncingAction = new Debouncer(300, (s) => Console.WriteLine(s));

            foreach (var s in new string[] { "a", "ab", "abc", "abcd", "abcde", "abcdef", "abcdefg", "abcdefgh", "abcdefghi" })
            {
                Thread.Sleep(100);
                DebouncingAction.Invoke(s);
            }

            DebouncingAction.Awaiter.GetResult();
        }
    }


    //запуск функции не чаще чем в N ms
    class Throttler
    {
        private readonly long _intervalms;
        private readonly Action<string> _action;
        private DateTime _lastInvocationTime = DateTime.MinValue;
        public Throttler(long intervalms, Action<string> action)
        {
            _intervalms = intervalms;
            _action = action;
        }

        public void Invoke(string arg)
        {
            if (_lastInvocationTime.AddMilliseconds(_intervalms) < DateTime.Now)
            {
                _action(arg);
                _lastInvocationTime = DateTime.Now;
            }
        }
    }


    //запуск функции не через N ms после последнего вызова
    class Debouncer
    {
        private readonly int _intervalms;
        private readonly Action<string> _action;
        private Task _task;
        private CancellationTokenSource _cancellation;
        object _locker = new object();

        public Debouncer(int intervalms, Action<string> action)
        {
            _intervalms = intervalms;
            _action = action;
        }

        public TaskAwaiter Awaiter => _task.GetAwaiter();

        public void Invoke(string s)
        {
            lock (_locker)
            {
                if (_task != null && !_task.IsCompleted)
                {
                    _cancellation.Cancel();
                }
                _cancellation = new CancellationTokenSource();
                _task = Task.Delay(_intervalms, _cancellation.Token).ContinueWith((t) => { if (!t.IsCanceled) { _action(s); } });
            }
        }
    }
}

using System;
using System.Threading;

namespace ConsoleApp1
{
    class Test
    {
        public void Execute()
        {
            Console.WriteLine("Trottling result");
            var trottledAction = new Throttler(300, (s) => Console.WriteLine());

            foreach (var s in new string[] { "a", "ab", "abc", "abcd", "abcde", "abcdef", "abcdefg", "abcdefgh", "abcdefghi" })
            {
                Thread.Sleep(100);
                trottledAction.Invoke(s);
            }
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
            }

            _lastInvocationTime = _lastInvocationTime.AddMilliseconds(_intervalms);
        }
    }


    //запуск функции не через N ms после последнего вызова
    class Debouncer
    {
        private readonly long intervalms;
        private readonly Action action;

        public Debouncer(long intervalms, Action action)
        {
            this.intervalms = intervalms;
            this.action = action;
        }

        public void Trigger()
        {

        }
    }
}

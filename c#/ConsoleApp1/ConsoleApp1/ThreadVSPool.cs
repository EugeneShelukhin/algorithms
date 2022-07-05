using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class ThreadVSPool
    {
        int limit = 1000000;
        public void ThreadTest()
        {
            Thread[] threads = new Thread[limit];
            var sw = new Stopwatch();
            sw.Start();

            for (var i = 0; i < limit; i++)
            {
                var t = new Thread(() => {; });
                t.Start();
                threads[i] = t;
            }

            foreach (var t in threads)
            {
                t.Join();
            }
            sw.Stop();
            Console.WriteLine("end of Threads: " + sw.Elapsed);
        }


        public void ThreadPoolTest()
        {
            Task[] threads = new Task[limit];
            var sw = new Stopwatch();
            sw.Start();

            for (var i = 0; i < limit; i++)
            {

                var t = Task.Factory.StartNew(() => {; });
                threads[i] = t;
            }

            Task.WaitAll(threads);

            sw.Stop();
            Console.WriteLine("end of ThreadPool: " + sw.Elapsed);
        }

    }
}

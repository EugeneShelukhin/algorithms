using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class MonitorWait
    {
        object o = new object();

        public void test()
        {
            var t1 = new Task(T1);
            t1.Start();
            Thread.Sleep(100);
            var t2 = new Task(T2);
            t2.Start();
            Task.WaitAll(t1, t2);
        }

        public void T1()
        {
            lock (o)
            {
                Console.WriteLine("Start T1");
                Thread.Sleep(2000);
                Console.WriteLine("before wait");
                Monitor.Wait(o);
                Console.WriteLine("End T1");
            }
        }
        public void T2()
        {
            lock (o)
            {
                Console.WriteLine("Start T2");
                Console.WriteLine("before pulse");
                //Monitor.Pulse(o);
                Console.WriteLine("after pulse");
                Console.WriteLine("End T2");
            }
        }
    }
}

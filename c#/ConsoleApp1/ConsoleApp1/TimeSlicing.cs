using System;
using System.Diagnostics;
using System.Threading;

namespace ConsoleApp1
{
    public class TimeSlicing
    {
        int limit = 1000000;
        public TimeSpan Result;
        public TimeSpan Result2;
        public void Test()
        {
            var sw = new Stopwatch();
            sw.Start();

            var t1 = new Thread(() =>
            {
                for (var i = 0; i < limit; i++)
                {
                    Thread.Yield();
                    Console.Write(".");
                }
            });
            t1.Start();

            //var t2 = new Thread(() =>
            //{
            //    for (var i = 0; i < limit; i++)
            //        Thread.Yield();
            //});
            //t2.Start();


            t1.Join();
            //t2.Join();
            sw.Stop();
            Console.WriteLine("end of yield cycles: " + sw.Elapsed);
            Result = sw.Elapsed;
        }

        public void TestEmpty()
        {
            var sw = new Stopwatch();
            sw.Start();

            var t1 = new Thread(() =>
            {
                for (var i = 0; i < limit; i++)
                { Console.Write(":"); }
            });
            t1.Start();

            //var t2 = new Thread(() =>
            //{
            //    for (var i = 0; i < limit; i++)
            //    { }
            //});
            //t2.Start();


            t1.Join();
            //t2.Join();
            sw.Stop();
            Console.WriteLine("end of empty cycles: " + sw.Elapsed);
            Result2 = sw.Elapsed;
        }
    }
}

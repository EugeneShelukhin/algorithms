using System;
using System.Diagnostics;
using System.Threading;

namespace ConsoleApp1
{
    public class LockFree
    {
        public void Test()
        {
            int value = 0;
            int limit = 100000000;
            var valObj = new ValObj();

            var w = new Stopwatch();
            w.Start();
            var x = new Thread(output1);
            var y = new Thread(output1);
            x.Start();
            y.Start();
            x.Join();
            y.Join();
            w.Stop();
            Console.WriteLine($"{w.Elapsed} {value}");
            value = 0;

            w = new Stopwatch();
            w.Start();
            x = new Thread(output2);
            y = new Thread(output2);
            x.Start();
            y.Start();
            x.Join();
            y.Join();
            w.Stop();
            Console.WriteLine($"{w.Elapsed} {value}");
            value = 0;

            for (var j = 0; j < 10; j++)
            {
                w = new Stopwatch();
                w.Start();
                x = new Thread(output3);
                y = new Thread(output3);
                x.Start();
                y.Start();
                x.Join();
                y.Join();
                w.Stop();
                Console.WriteLine($"3 {w.Elapsed} {value}");
                value = 0;

                w = new Stopwatch();
                w.Start();
                x = new Thread(output4);
                y = new Thread(output4);
                x.Start();
                y.Start();
                x.Join();
                y.Join();
                w.Stop();
                Console.WriteLine($"4 {w.Elapsed} {value}");
                value = 0;
            }

            Console.WriteLine("End ");
            Console.ReadLine();


            void output1()
            {

                for (int i = 0; i < limit; i++)
                {
                    value++;
                }
            }

            void output2()
            {
                for (int i = 0; i < limit; i++)
                {
                    Interlocked.Increment(ref value);
                }
            }

            void output3()
            {
                count1 = 0;
                for (int i = 0; i < limit; i++)
                {
                    LockFreeUpdate(ref value, (v) => { v++; return v; });
                }
                Console.WriteLine($"3 count1={count1}");
            }

            void output4()
            {
                count2 = 0;
                for (int i = 0; i < limit; i++)
                {
                    LockFreeUpdate2(ref value, (v) => { v++; return v; });
                }
                Console.WriteLine($"4 count2={count2}");
            }
        }

        class ValObj
        {
            public int value = 0;
        }

        static long count1 = 0;
        static long count2 = 0;

        static void LockFreeUpdate(ref int field, Func<int, int> updateFunction)
        //where T : class
        {
            var spinWait = new SpinWait();
            while (true)
            {
                int snapshot1 = field;
                int calc = updateFunction(snapshot1);
                int snapshot2 = Interlocked.CompareExchange(ref field, calc, snapshot1);
                if (snapshot1 == snapshot2) return;
                spinWait.SpinOnce();
                Interlocked.Increment(ref count1);
            }
        }

        static void LockFreeUpdate2(ref int field, Func<int, int> updateFunction)
        //where T : class
        {
            var spinWait = new SpinWait();
            while (true)
            {
                int snapshot1 = field;
                int calc = updateFunction(snapshot1);
                int snapshot2 = Interlocked.CompareExchange(ref field, calc, snapshot1);
                if (snapshot1 == snapshot2) return;
                Interlocked.Increment(ref count2);
            }
        }
    }
}

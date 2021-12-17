using System;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class deadlock
    {
        object A = new object();
        object B = new object();

        public void Test()
        {
            var a = new Task(TestA);
            var b = new Task(TestB);
            a.Start();
            b.Start();
            Task.WaitAll(a, b);

        }

        private void TestA()
        {
            lock (A)
            {
                //Console.WriteLine("TestA1");
                //Thread.Sleep(1000);
                lock (B)
                {
                    Console.WriteLine("TestA2");
                }
            }
        }
        private void TestB()
        {
            lock (B)
            {
                //Console.WriteLine("TestB1");
                //Thread.Sleep(1000);
                lock (A)
                {
                    Console.WriteLine("TestB2");
                }
            }
        }


    }
}

using System;
using System.Threading;

namespace ConsoleApp1
{
    class XY
    {
        bool done;
        public void test()
        {
            var x = new Thread(output);
            //var y = new Thread(output);
            x.Start("x");
            //y.Start("y");
            //x.Join();
            //y.Join();


            Console.WriteLine("End");
            Console.ReadLine();
        }


        public void output(object xy)
        {
            for (int i = 0; i < 10; i++)
            {
                var j = i;
                new Thread(() => Console.Write(j)).Start();
            }


            //if (!done)
            //{
            //    done = true;
            //    Console.WriteLine("done");
            //}



            //for (var i = 0; i < 10000; i++)
            //{
            //    Console.Write(xy);
            //    Thread.Yield();
            //}
        }
    }
}

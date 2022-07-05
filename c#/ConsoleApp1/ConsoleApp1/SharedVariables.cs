using System;
using System.Threading;

namespace ConsoleApp1
{
    public class SharedVariables
    {
        public void Test()
        {
            var signal = new ManualResetEvent(false);
            new Thread(() =>
            {
                Console.WriteLine("Waiting for signal...");
                signal.WaitOne();
                signal.Dispose();
                Console.WriteLine("Got signal!");
            }).Start();
            Thread.Sleep(2000);
            signal.Set();
        }
    }
}

using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class TaskCompletionSource
    {
        public void Test()
        {
            var tcs = new TaskCompletionSource<int>();
            new Thread(() => { Thread.Sleep(5000); tcs.SetResult(42); }).Start();

            Console.WriteLine(tcs.Task.Result);

            //(new Task(() => { })).Delay(100);
        }



    }
}

using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Tasks
    {
        public void Test()
        {
            TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;

            Task.Run(() =>
            {
                Thread.Sleep(300);
                throw new Exception();
            });
        }

        private void TaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            Console.WriteLine("Test " + e.Exception.Message);
        }
    }
}

using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace AsyncProgrammingDemo
{
    public class ParallelTasksProgram : IProgram
    {
        public async Task ExecuteAsync()
        {
            var stopwatch = new Stopwatch();
            
            Console.WriteLine("Starting executing");
            stopwatch.Start();

            var task1 = SomeLongAwaitingTaskAsync();
            var task2 = SomeLongAwaitingTaskAsync();
            var task3 = SomeLongAwaitingTaskAsync();
            
            await Task.WhenAll(task1, task2, task3);
            stopwatch.Stop();

            Console.WriteLine(stopwatch.ElapsedMilliseconds);
        }

        private async Task SomeLongAwaitingTaskAsync()
        {
            await Task.Delay(TimeSpan.FromSeconds(2));
        }
    }
}
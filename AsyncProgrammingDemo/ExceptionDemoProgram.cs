using System;
using System.Threading.Tasks;

namespace AsyncProgrammingDemo
{
    public class ExceptionDemoProgram : IProgram
    {
        public async Task ExecuteAsync()
        {
            Task allTasks = Task.CompletedTask;
            try
            {
                var task1 = WaitForSmthAsync(1);
                var task2 = WaitForSmthAsync(2);
                var task3 = WaitForSmthAsync(3);

                allTasks = Task.WhenAll(task1, task2, task3);
                await allTasks;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception Message: {e.Message}");
                Console.WriteLine($"Exception Type: {e.GetType().Name}");
                Console.WriteLine($"Is Faulted: {allTasks.IsFaulted}");

                if (allTasks.Exception is not null)
                {
                    foreach (var taskException in allTasks.Exception?.InnerExceptions)
                    {
                        Console.WriteLine($"Exception Message: {taskException.Message}");
                    }
                }
            }
        }

        private async Task WaitForSmthAsync(int taskIndex)
        {
            await Task.Delay(TimeSpan.FromMilliseconds(1));
            throw new InvalidOperationException($"The task {taskIndex} finished with failure");
        }
    }
}
using System;
using System.Threading.Tasks;

namespace AsyncProgrammingDemo
{
    /// <summary>
    /// 0 - GettingTaskWithoutAwaitProgram, ParallelTasksProgram
    /// 1 - ExceptionDemoProgram
    /// 2 - CancellationTaskProgram
    /// </summary>
    internal static class Program
    {
        private static readonly IProgram _program = new ExceptionDemoProgram();

        private static async Task Main(string[] args)
        {
            await _program.ExecuteAsync();

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
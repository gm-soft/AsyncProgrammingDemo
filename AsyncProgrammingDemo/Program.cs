using System;
using System.Threading.Tasks;

namespace AsyncProgrammingDemo
{
    internal static class Program
    {
        private static readonly IProgram _program = new ParallelTasksProgram();

        private static async Task Main(string[] args)
        {
            await _program.ExecuteAsync();

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
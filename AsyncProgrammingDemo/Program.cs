using System;
using System.Threading.Tasks;

namespace AsyncProgrammingDemo
{
    internal static class Program
    {
        private static readonly IProgram _program = new CancellationTaskProgram();

        private static async Task Main(string[] args)
        {
            await _program.ExecuteAsync();

            Console.ReadKey();
        }
    }
}
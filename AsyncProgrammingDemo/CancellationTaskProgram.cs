using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncProgrammingDemo
{
    public class CancellationTaskProgram : IProgram
    {
        private readonly CancellationTokenSource _cancellationTokenSource = new ();
        
        public async Task ExecuteAsync()
        {
            StartCtsCancellationAsync();

            await DoSmthAsync(_cancellationTokenSource.Token);
        }

        private async void StartCtsCancellationAsync()
        {
            await Task.Delay(2_000);
            _cancellationTokenSource.Cancel();
        }

        private async Task DoSmthAsync(CancellationToken token)
        {
            Console.WriteLine("Executing");
            while (true)
            {
                Console.Write(".");
                await Task.Delay(TimeSpan.FromMilliseconds(200), token);
            }
        }
    }
}
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AsyncProgrammingDemo
{
    public class GettingTaskWithoutAwaitProgram : IProgram
    {
        public async Task ExecuteAsync()
        {
            Console.WriteLine(await GetContentByUrlAsync());
        }
        
        private async Task<int> GetContentByUrlAsync()
        {
            using var client = new HttpClient();

            Task<string> contentTask = client.GetStringAsync("https://google.com");

            WriteSomethingElse();

            string content = await contentTask;
            return content.Length;
        }
        
        private void WriteSomethingElse()
        {
            Console.WriteLine("Something else");
        }
    }
}
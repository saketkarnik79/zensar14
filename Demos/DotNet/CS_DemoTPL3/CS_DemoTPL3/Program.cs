namespace CS_DemoTPL3
{
    internal class Program
    {
        static void Main(string[] args)
        {
             var urls=new List<string>
             {
                  "https://www.example.com",
                  "https://www.microsoft.com",
                  "https://www.github.com",
                  "https://www.stackoverflow.com"
             };
            var options = new ParallelOptions
            {
                MaxDegreeOfParallelism = Environment.ProcessorCount // Limit to 2 concurrent tasks
            };

            Parallel.ForEach(urls, options, url =>
            {
                using (var client = new HttpClient())
                {
                    Console.WriteLine($"Downloading {url} on thread {Task.CurrentId}");
                    // Simulate work
                    Task.Delay(1000).Wait();
                    //var content = client.GetStringAsync(url).Result;
                    //Console.WriteLine($"Fetched {content.Length} characters from {url}");
                    Console.WriteLine($"Completed downloading {url} on thread {Task.CurrentId}");
                }
            });
            Console.WriteLine("All downloads completed.");

            Console.WriteLine("Program completed. Press any key to exit...");
            Console.ReadKey();
        }
    }
}

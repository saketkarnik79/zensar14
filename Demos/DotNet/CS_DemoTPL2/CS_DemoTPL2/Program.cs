namespace CS_DemoTPL2
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var urls = new List<string>
            {
                "https://aninvalidurl.test",
                "https://www.example.com",
                "https://www.microsoft.com",
                "https://anotherinvalidurl.test",
                "https://www.github.com"
            };
            var tasks = new List<Task<string>>();
            foreach (var url in urls)
            {
                tasks.Add(DownloadContentAsync(url));
            }

            var allTasks = Task.WhenAll(tasks);

            try
            {
                //Wait for all tasks to complete
                await allTasks;
                Console.WriteLine("All downloads completed successfully.");
            }
            catch
            {
                Console.WriteLine("One or more downloads failed:");
                foreach (var innerEx in allTasks?.Exception?.InnerExceptions ?? Enumerable.Empty<Exception>())
                {
                    Console.WriteLine($" - {innerEx.GetType().Name}: {innerEx.Message}");
                }
            }

            Console.WriteLine("program completed. Press any key to exit...");
            Console.ReadKey();
        }

        static async Task<string> DownloadContentAsync(string url)
        {
            using var httpClient = new HttpClient();
            Console.WriteLine($"Starting download: {url}");
            return await httpClient.GetStringAsync(url);
        }
    }
}

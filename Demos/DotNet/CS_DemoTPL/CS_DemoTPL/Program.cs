namespace CS_DemoTPL
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //var urls =new List<string>
            //{
            //    "https://www.zensar.com",
            //    "https://www.optimistikinfo.com",
            //    "https://learnx.optimistikinfo.com"
            //};

            //var cts = new CancellationTokenSource();
            //var progress = new Progress<string>(status =>
            //{
            //    Console.WriteLine($"Progress: {status}");
            //});
            //Console.WriteLine("Press 'c' to cancel...");
            //Task.Run(() =>
            //{
            //    if (Console.ReadKey().KeyChar == 'c')
            //    {
            //        cts.Cancel();
            //    }
            //});

            //try
            //{
            //    //var contents = await DownloadAllAsync(urls, progress, cts.Token);
            //    //Console.WriteLine("\nDownloaded Completed. Contents: ");
            //    //foreach (var content in contents)
            //    //{
            //    //    Console.WriteLine($"Content length: {content.Length}");
            //    //}
            //    //string firstContent = await DownloadFirstAsync(urls, progress, cts.Token);
            //    //Console.WriteLine($"\nFirst completed download content length: {firstContent.Length}");

            //    string firstContent = await DownloadFirstAndCancelOtherAsync(urls, progress, cts);
            //    Console.WriteLine($"\nFirst completed download content length: {firstContent.Length}");
            //}
            //catch (OperationCanceledException)
            //{
            //    Console.WriteLine("\nDownload cancelled by user.");
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"\nAn error occurred: {ex.Message}");
            //}

            try
            {
                await DownloadAllAsync2();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Network error: {ex.Message}");
            }
            catch(OperationCanceledException)
            {
                Console.WriteLine("Operation was canceled.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}.");
            }
           

            Console.WriteLine("Program completed. Press any key to exit...");
            Console.ReadKey();
        }

        static async Task DownloadAllAsync2()
        {
            var urls = new List<string>
            {
                "https://aninvalidurl.test",
                "https://www.zensar.com",
                "https://www.optimistikinfo.com",
                "https://learnx.optimistikinfo.com"
            };
            var tasks = urls.Select(url => DownloadContent2Async(url)).ToList();
            try
            {
                await Task.WhenAll(tasks);
            }
            catch
            {
                foreach (var task in tasks)
                {
                    if (task.IsFaulted)
                    {
                        Console.WriteLine($"Task failed with exception: {task.Exception?.InnerException?.Message}");
                    }
                }

                throw; //Rethrow to be handled by the caller
            }
        }

        static async Task<string> DownloadContent2Async(string url)
        {
            using var httpClient = new HttpClient();
            Console.WriteLine($"Starting download from {url}");
           return await httpClient.GetStringAsync(url);
            //Console.WriteLine($"Completed download from {url}");
        }

        static async Task<string> DownloadFirstAndCancelOtherAsync(List<string> urls, IProgress<string> progress, CancellationTokenSource cancellationToken)
        {
            var tasks = new List<Task<string>>();
            foreach (var url in urls)
            {
                tasks.Add(DownloadContentAsync(url, progress, cancellationToken.Token));
            }
            var firstCompletedTask = await Task.WhenAny(tasks);
            cancellationToken.Cancel(); // Cancel other tasks
            cancellationToken.Token.ThrowIfCancellationRequested();
            return await firstCompletedTask;
        }

        static async Task<string> DownloadFirstAsync(List<string> urls, IProgress<string> progress, CancellationToken cancellationToken)
        {
            var tasks = new List<Task<string>>();
            foreach (var url in urls)
            {
                tasks.Add(DownloadContentAsync(url, progress, cancellationToken));
            }
            var firstCompletedTask = await Task.WhenAny(tasks);
            cancellationToken.ThrowIfCancellationRequested();
            return await firstCompletedTask;
        }

        static async Task<List<string>> DownloadAllAsync(List<string> urls, IProgress<string> progress, CancellationToken cancellationToken)
        {
            var tasks = new List<Task<string>>();

            foreach (var url in urls)
            {
                tasks.Add(DownloadContentAsync(url, progress, cancellationToken));
            }
            var results = await Task.WhenAll(tasks);
            return new List<string>(results);
        }

        static async Task<string> DownloadContentAsync(string url, IProgress<string> progress, CancellationToken cancellationToken)
        {
            using var httpClient = new HttpClient();
            progress.Report($"Starting download from {url}");
            var content = await httpClient.GetStringAsync(url, cancellationToken);
            progress.Report($"Completed download from {url}");
            return content;
        }
    }
}

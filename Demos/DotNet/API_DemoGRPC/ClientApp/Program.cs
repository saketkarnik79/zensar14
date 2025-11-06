using Grpc.Core;
using Grpc.Net.Client;
using Grpc.Net.ClientFactory;
using System.Threading.Tasks;
using ClientApp.Interceptors;
using Grpc.Core.Interceptors;
using Client;
using System.Net.Http.Headers;
using System.Net.Http;
using Polly;
using Polly.Extensions.Http;
using Microsoft.Extensions.DependencyInjection;

namespace ClientApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Task.Delay(3000).Wait();

            //var authChannel = GrpcChannel.ForAddress("https://localhost:7191");

            //var authClient = new AuthService.AuthServiceClient(authChannel);
            //var tokenReply = await authClient.GetTokenAsync(new TokenRequest { UserName = "Client User" });
            //var token = tokenReply.Token;


            //var creds = CallCredentials.FromInterceptor((context, metadata) => 
            //{
            //    metadata.Add("Authorization", $"Bearer {token}");
            //    return Task.CompletedTask;
            //});
            //var channel = GrpcChannel.ForAddress("https://localhost:7191", new GrpcChannelOptions() { Credentials = ChannelCredentials.Create(new SslCredentials(), creds) });


            //var client = new Greeter.GreeterClient(channel);
            //var client = new Greeter.GreeterClient(interceptor);
            //var interceptor = channel.Intercept(new ClientLoggingInterceptor());

            //var client = new Greeter.GreeterClient(channel);
            //        var httpClient = new HttpClient();
            //        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            //        var channel = GrpcChannel.ForAddress("https://localhost:7191",
            //new GrpcChannelOptions { HttpClient = httpClient });
            //        var client = new Greeter.GreeterClient(channel);
            //        try
            //        {
            //            var reply = await client.SayHelloAsync(new HelloRequest { Name = "James" });
            //            Console.WriteLine($"Response: {reply.Message}");
            //        }
            //        catch (RpcException ex)
            //        {
            //            //Console.WriteLine(ex.Message );
            //            Console.WriteLine($"RPC Error: {ex.Status.Detail}");
            //        }
            //        catch (Exception ex)
            //        {
            //            Console.WriteLine(ex.Message);
            //        }

            //var channel = GrpcChannel.ForAddress("https://localhost:7191");
            //var client = new ChatService.ChatServiceClient(channel);

            //using (var call = client.ChatStream())
            //{
            //    var sendTask = Task.Run(async () => 
            //    {
            //        while(true)
            //        {
            //            Console.Write("You: ");
            //            var input = Console.ReadLine();
            //            if (string.IsNullOrWhiteSpace(input)) break;

            //            await call.RequestStream.WriteAsync(new ChatMessage() { User = "Client User", Message = input });
            //        }
            //        await call.RequestStream.CompleteAsync();
            //    });

            //    var receiveTask = Task.Run(async () => 
            //    {
            //        await foreach (var response in call.ResponseStream.ReadAllAsync())
            //        {
            //            Console.WriteLine($"Server: {response.Message}");
            //        }
            //    });
            //    await Task.WhenAll(sendTask, receiveTask);
            //}

            var services = new ServiceCollection();
            services.AddGrpcClient<Greeter.GreeterClient>(options =>
            {
                options.Address = new Uri("https://localhost:7191");
            })
                .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler())
                .AddPolicyHandler(GetRetryPolicy())
                .AddPolicyHandler(GetCircuitBreakerPolicy());
            var provider = services.BuildServiceProvider();
            var client = provider.GetRequiredService<Greeter.GreeterClient>();

            try
            {
                var reply = await client.SayHelloAsync(new HelloRequest { Name = "James" });
                Console.WriteLine($"Response: {reply.Message}");
            }
            catch (RpcException ex)
            {
                //Console.WriteLine(ex.Message );
                Console.WriteLine($"RPC Error: {ex.Status.Detail}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Program completed. Press any key to quit...");
            Console.ReadKey();
        }

        private static IAsyncPolicy<HttpResponseMessage> GetCircuitBreakerPolicy()
        {
            return HttpPolicyExtensions.HandleTransientHttpError()
                .CircuitBreakerAsync(5, TimeSpan.FromSeconds(30));
        }

        private static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            return HttpPolicyExtensions.HandleTransientHttpError().WaitAndRetryAsync(3,
                retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
        }
    }
}

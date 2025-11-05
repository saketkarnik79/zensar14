using Grpc.Core;
using System.Threading.Channels;

namespace API_DemoGRPC.Services
{
    public class Chat: ChatService.ChatServiceBase
    {
        public override async Task ChatStream(IAsyncStreamReader<ChatMessage> requestStream, IServerStreamWriter<ChatMessage> responseStream, ServerCallContext context)
        {
            var channel = Channel.CreateUnbounded<ChatMessage>();

            //Receive messages from the client
            _ = Task.Run(async () => 
            {
                await foreach (var message in requestStream.ReadAllAsync())
                {
                    Console.WriteLine($"Received from {message.User}: {message.Message}");
                    await channel.Writer.WriteAsync(new ChatMessage() { User = "Server", Message = $"Echo: {message.Message}" });
                }
                channel.Writer.Complete();
            });

            //Sending messages to client
            await foreach (var message in channel.Reader.ReadAllAsync())
            {
                await responseStream.WriteAsync(message);
            }
        }
    }
}

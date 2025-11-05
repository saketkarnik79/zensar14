using Grpc.Core;
using Grpc.Core.Interceptors;

namespace API_DemoGRPC.Interceptors
{
    public class ServerLoggingInterceptor: Interceptor
    {
        private readonly ILogger<ServerLoggingInterceptor> _logger;

        public ServerLoggingInterceptor(ILogger<ServerLoggingInterceptor> logger)
        {
            _logger = logger;
        }

        public override async Task<TResponse> UnaryServerHandler<TRequest, TResponse>(TRequest request, ServerCallContext context, UnaryServerMethod<TRequest, TResponse> continuation)
        {
            _logger.LogInformation($"Received request: {context.Method} with payload: {request}");
            try
            {
                return await continuation(request, context);
            }
            catch (RpcException ex)
            {
                _logger.LogError(ex, $"Error occurred while processing request: {context.Method}, Message: {ex.Message}");
                throw;
            }
        }
    }
}

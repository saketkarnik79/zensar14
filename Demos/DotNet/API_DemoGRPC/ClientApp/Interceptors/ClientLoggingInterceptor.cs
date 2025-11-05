using Grpc.Core;
using Grpc.Core.Interceptors;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp.Interceptors
{
    public class ClientLoggingInterceptor : Interceptor
    {
        //private readonly ILogger<ClientLoggingInterceptor> _logger;

        //public ClientLoggingInterceptor(ILogger<ClientLoggingInterceptor> logger)
        //{
        //    _logger = logger;
        //}

        public override AsyncUnaryCall<TResponse> AsyncUnaryCall<TRequest, TResponse>(TRequest request, ClientInterceptorContext<TRequest, TResponse> context, AsyncUnaryCallContinuation<TRequest, TResponse> continuation)
        {
            //_logger.LogInformation($"Sending request: {context.Method} with payload: {request}");
            Console.WriteLine($"Sending request: {context.Method.FullName} with payload: {request}");
            return continuation(request, context);
        }
    }
}

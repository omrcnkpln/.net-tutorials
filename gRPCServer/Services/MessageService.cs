using Grpc.Core;
using gRPCMessageServer;
using gRPCServer;

namespace gRPCServer.Services
{
    public class MessageService : Message.MessageBase
    {
        //unary
        //public override async Task<MessageResponse> SendMessage(MessageRequest request, ServerCallContext context)
        //{
        //    Console.WriteLine($"Received message: {request.Message}");

        //    var messageResponse = new MessageResponse
        //    {
        //        Message = "Hello from gRPC server"
        //    };

        //    return messageResponse;
        //}

        //server streaming
        //public override async Task SendMessage(MessageRequest request, IServerStreamWriter<MessageResponse> responseStream, ServerCallContext context)
        //{
        //    Console.WriteLine($"Received message: {request.Message}");

        //    for (int i = 0; i < 10; i++)
        //    {
        //        await Task.Delay(200);
        //        responseStream.WriteAsync(new MessageResponse
        //        {
        //            Message = $"Hello from gRPC server {i}"
        //        });
        //    }
        //}

        //client streaming
        //public override async Task<MessageResponse> SendMessage(IAsyncStreamReader<MessageRequest> requestStream, ServerCallContext context)
        //{
        //    while (await requestStream.MoveNext(context.CancellationToken))
        //    {
        //        Console.WriteLine($"Message aldındı{requestStream.Current.Message}");
        //    }

        //    return new MessageResponse
        //    {
        //        Message = "Hello from gRPC server"
        //    };
        //}

        //bidirectional streaming
        public override async Task SendMessage(IAsyncStreamReader<MessageRequest> requestStream, IServerStreamWriter<MessageResponse> responseStream, ServerCallContext context)
        {
            var task1 = Task.Run(async () =>
            {
                while (await requestStream.MoveNext(context.CancellationToken))
                {
                    Console.WriteLine($"Message aldındı{requestStream.Current.Message}");
                    //await responseStream.WriteAsync(new MessageResponse
                    //{
                    //    Message = $"Hello from gRPC server {requestStream.Current.Message}"
                    //});
                }
            });

            for (int i = 0; i < 10; i++)
            {
                await Task.Delay(1000);
                responseStream.WriteAsync(new MessageResponse
                {
                    Message = $"Hello from gRPC server {i}"
                });
            }

            await task1;
        }
    }
}
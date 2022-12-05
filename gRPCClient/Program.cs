using Grpc.Net.Client;
using gRPCMessageClient;

internal class Program
{
    private static async global::System.Threading.Tasks.Task Main(string[] args)
    {
        var channel = GrpcChannel.ForAddress("https://localhost:7154");


        //var greetClient = new Greeter.GreeterClient(channel);

        //HelloReply result = greetClient.SayHello(new HelloRequest
        //{
        //    Name = "omrcnkpln request"
        //});

        var messageClient = new Message.MessageClient(channel);

        //Unary
        //var result = await messageClient.SendMessageAsync(new MessageRequest
        //{
        //    Message = "omrcnkpln request"
        //});
        //Console.WriteLine(result.Message);


        //server streaming
        //var response = messageClient.SendMessage(new MessageRequest
        //{
        //    Message = "omrcnkpln request"
        //});

        CancellationTokenSource cts = new CancellationTokenSource();
        //while (await response.ResponseStream.MoveNext(cts.Token))
        //{
        //    Console.WriteLine(response.ResponseStream.Current.Message);
        //}

        //client streaming
        //var request = messageClient.SendMessage();

        //for (int i = 0; i < 10; i++)
        //{
        //    await Task.Delay(200);
        //    await request.RequestStream.WriteAsync(new MessageRequest
        //    {
        //        Message = $"omrcnkpln request {i}"
        //    });
        //}

        //request.RequestStream.CompleteAsync();

        //Console.WriteLine((await request.ResponseAsync).Message);

        //Bi - directional streaming
        var request = messageClient.SendMessage();
        //var response = request.ResponseStream;

        var task1 = Task.Run(async () =>
        {
            for (int i = 0; i < 10; i++)
            {
                await Task.Delay(1000);
                await request.RequestStream.WriteAsync(new MessageRequest
                {
                    Message = $"omrcnkpln request {i}"
                });
            }
            request.RequestStream.CompleteAsync();
        });

        while (await request.ResponseStream.MoveNext(cts.Token))
        {
            Console.WriteLine(request.ResponseStream.Current.Message);
        }

        await task1;
        request.RequestStream.CompleteAsync();
    }
}   
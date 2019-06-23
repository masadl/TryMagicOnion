using Grpc.Core;
using MagicOnion.Client;
using System;

class Program
{
    static void Main(string[] args)
    {
        // standard gRPC channel
        var channel = new Channel("localhost", 12345, ChannelCredentials.Insecure);

        // get MagicOnion dynamic client proxy
        var client = MagicOnionClient.Create<IMyFirstService>(channel);

        // call method.
        var result = client.SumAsync(100, 200).GetAwaiter().GetResult();

        Console.WriteLine("Client Received:" + result);
    }
}
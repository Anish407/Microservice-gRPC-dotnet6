using Grpc.Core;
using Grpc.Net.Client;
using ProductGrpc.Protos.ServerStream;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


Console.WriteLine("Start gRPC client -- Unary calls");

using var channel = GrpcChannel.ForAddress("https://localhost:5001");
var client  = new InfoServerStream.InfoServerStreamClient(channel);

using var clientData = client.GetAllInfo(new Google.Protobuf.WellKnownTypes.Empty());


await foreach (var item in clientData.ResponseStream.ReadAllAsync())
{
    Console.WriteLine(item.ToString());
}

Console.ReadKey();
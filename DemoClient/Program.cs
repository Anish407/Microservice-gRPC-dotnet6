// See https://aka.ms/new-console-template for more information

using DemogRPC.Protos;
using Grpc.Net.Client;

Console.WriteLine("Hello, World!");

//create a channel that connects to the server
var channel = GrpcChannel.ForAddress("https://localhost:5001");

//Pass the channel to the client that we generated from the proto buf file
var client = new DemoGrpcService.DemoGrpcServiceClient(channel);

var response = await client.demomessageAsync(new HelloRequest { Name = "Anish" });

Console.WriteLine($"{response.Name} {response.Iteration}");

Console.ReadKey();


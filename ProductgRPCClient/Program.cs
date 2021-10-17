using Grpc.Net.Client;
using ProductGrpc.Protos.Product;

Console.WriteLine("Start gRPC client -- Unary calls");

using var channel = GrpcChannel.ForAddress("https://localhost:5001");
var client = new ProductProtoService.ProductProtoServiceClient(channel);

// call get Product gRPC service and display the result
Console.WriteLine("__________________ Start ______________________");

var response = client.GetProduct(new GetProductRequest
{
    ProductId = 1
});

Console.WriteLine($"Response: {response.ToString()}");
Console.WriteLine("__________________ Complete ______________________");
Console.ReadLine();

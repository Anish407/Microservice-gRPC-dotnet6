using Microsoft.EntityFrameworkCore;
using ProductGrpc.Data;
using ProductGrpc.Services;
using ProductGrpc.Services.Products;
using static ProductGrpc.common.Constants.Constants;
using Microsoft.Extensions.DependencyInjection;
using ProductGrpc.Models;

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682




// Add services to the container.
builder.Services.AddGrpc();

//builder.Services.AddDbContext<DbContext, ProductContext>(op => op.UseSqlServer(@"Server=LAPTOP-FSA8LOOJ\SQLEXPRESS;Database=productgrpc;Trusted_Connection=True;"));

var products= new List<Product>() 
{
        new Product(){
            Id = 1,
            Name = "Mi10T",
            Description = "New Xiaomi Phone Mi10T",
            Price = 699,
            Status = ProductGrpc.Models.ProductStatus.INSTOCK,
            CreatedTime = DateTime.UtcNow
        },
          new Product
          {
              Id = 2,
              Name = "P40",
              Description = "New Huawei Phone P40",
              Price = 899,
              Status = ProductGrpc.Models.ProductStatus.INSTOCK,
              CreatedTime = DateTime.UtcNow
          },
          new Product
          {
              Id = 3,
              Name = "A50",
              Description = "New Samsung Phone A50",
              Price = 399,
              Status = ProductGrpc.Models.ProductStatus.INSTOCK,
              CreatedTime = DateTime.UtcNow
          }
};

builder.Services.AddScoped<List<Product>>(svc=> products);

var app = builder.Build();



//var context = app.Services.GetRequiredService<ProductContext>();
//DataGenerator.SeedData(context);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

//app.MapGrpcService<GreeterService>();
app.MapGrpcService<ProductService>();
app.MapGrpcService<InfoService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();



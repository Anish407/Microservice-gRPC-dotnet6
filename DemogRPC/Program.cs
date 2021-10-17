using DemogRPC.Services;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddLogging();

//add the needed gRPC services to the DI container
builder.Services.AddGrpc();

//builder.Services.AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("v1", new() { Title = "DemogRPC", Version = "v1" });
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    //app.UseSwagger();
    //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DemogRPC v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.MapGrpcService<DemoMessageService>();
//app.MapControllers();
app.Run();

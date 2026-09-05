using System.Threading.Channels;
using WebApplication1.Endpoints;
using WebApplication1.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddMemoryCache();

builder.Services.AddSingleton(x => Channel.CreateBounded<Product>(new BoundedChannelOptions(100)));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) app.MapOpenApi();

app.UseHttpsRedirection();


app.MapProductEndpoints();


app.Run();
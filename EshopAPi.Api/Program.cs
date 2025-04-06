using EshopApi.Core.Interfaces;
using EshopApi.Infrastructure.Repositories;
using EshopApi.UseCases.Product.Create;
using FastEndpoints;
using FastEndpoints.Swagger;
using MediatR;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddMediatR(typeof(CreateProductHandler).Assembly);

builder.Services.AddFastEndpoints();
builder.Services.AddEndpointsApiExplorer();

builder.Services.SwaggerDocument(o =>
{
    o.ShortSchemaNames = true;
});

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseFastEndpoints();
app.UseSwaggerGen();
app.Run();

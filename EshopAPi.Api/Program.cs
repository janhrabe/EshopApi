using EshopApi.Core.Entities;
using EshopApi.Core.Interfaces;
using EshopApi.Infrastructure.Data;
using EshopApi.Infrastructure.Repositories;
using EshopApi.UseCases.Product.GetList;
using EshopApi.UseCases.Product.Update;
using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EshopApiConnection")));

builder.Services.AddScoped<IRepository<Product>, ProductRepository>();

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssemblyContaining<UpdateProductHandler>());

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetListCommand).Assembly));

builder.Services.AddFastEndpoints();

builder.Services.AddEndpointsApiExplorer();

builder.Services.SwaggerDocument(o =>
{
    o.MaxEndpointVersion = 2;
    o.DocumentSettings = s =>
    {
        s.DocumentName = "v1";
        s.Title = "Eshop API";
        s.Version = "v0";
    };
});

builder.Services.SwaggerDocument(o =>
{
    o.DocumentSettings = s =>
    {
        s.DocumentName = "v2";
        s.Title = "Eshop API";
        s.Version = "v1";
    };
});

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

    app.UseSwaggerUi();
}

app.UseHttpsRedirection();
app.UseFastEndpoints();
app.UseSwaggerGen();
app.Run();

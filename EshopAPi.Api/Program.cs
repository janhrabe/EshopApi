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
    options.UseNpgsql(builder.Configuration.GetConnectionString("EshopApiConnection")));

builder.Services.AddScoped<IRepository<Product>, ProductRepository>();

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssemblyContaining<UpdateProductHandler>());

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetListCommand).Assembly));

builder.Services.AddFastEndpoints();
builder.Services.AddEndpointsApiExplorer();

builder.Services.SwaggerDocument(o =>
{
    o.ShortSchemaNames = true;
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

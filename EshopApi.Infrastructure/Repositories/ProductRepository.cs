using EshopApi.Core.Entities;
using EshopApi.Core.Interfaces;
using EshopApi.Infrastructure.Data;

namespace EshopApi.Infrastructure.Repositories;

public class ProductRepository: Repository<Product>, IProductRepository
{
    public ProductRepository(AppDbContext context) : base(context)
    {
        
    }   
}
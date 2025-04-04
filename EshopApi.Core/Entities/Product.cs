using EshopApi.Core.Interfaces;

namespace EshopApi.Core.Entities;

public class Product : IEntity
{
    public Guid Id { get; set; }
    
    public required string Name { get; set; }
    
    public required string ImageUrl { get; set; }
    
    public decimal? Price { get; set; }
    
    public string? Description { get; set; }
    
    public int QuantityInStock { get; set; }
}
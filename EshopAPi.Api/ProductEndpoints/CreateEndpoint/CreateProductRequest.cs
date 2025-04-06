namespace EshopAPi.Api.ProductEndpoints.CreateEndpoint;

public class CreateProductRequest
{
    public required string Name { get; set; }
    
    public required string ImageUrl { get; set; }
    
    public decimal Price { get; set; }
    
    public string? Description { get; set; }
    
    public int QuantityInStock { get; set; }
}
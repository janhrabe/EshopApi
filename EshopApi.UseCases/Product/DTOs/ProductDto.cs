namespace EshopApi.UseCases.Product.DTOs;

public record ProductDto(string Name, string ImageUrl,decimal Price , string? Description, int QuantityInStock);
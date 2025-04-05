namespace EshopApi.UseCases.Product.DTOs;

public record ListProductDto(string Name, string ImageUrl, decimal Price, int QuantityInStock);
using EshopApi.Core;
using MediatR;

namespace EshopApi.UseCases.Product.Create;

public record CreateProductCommand(string Name, string ImageUrl, decimal Price, string? Description, int QuantityInStock) : IRequest<Result<Guid>>;
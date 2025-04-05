using EshopApi.Core;
using EshopApi.UseCases.Product.DTOs;
using MediatR;
using ProductEntity = EshopApi.Core.Entities.Product;

namespace EshopApi.UseCases.Product.GetProductById;

public record GetProductByIdCommand(Guid Id) : IRequest<Result<ProductDto>>;
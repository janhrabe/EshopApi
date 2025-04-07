using EshopApi.Core;
using EshopApi.UseCases.Product.DTOs;
using MediatR;

namespace EshopApi.UseCases.Product.GetProductById;

public record GetProductByIdCommand(Guid Id) : IRequest<Result<ProductDto>>;
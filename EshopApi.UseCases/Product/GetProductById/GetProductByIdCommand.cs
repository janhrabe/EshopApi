using EshopApi.Core;
using MediatR;
using ProductEntity = EshopApi.Core.Entities.Product;

namespace EshopApi.UseCases.Product.GetProductById;

public record GetProductByIdCommand(Guid Id) : IRequest<Result<ProductEntity>>;
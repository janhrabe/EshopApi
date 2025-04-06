using EshopApi.Core;
using EshopApi.UseCases.Product.DTOs;
using MediatR;

namespace EshopApi.UseCases.Product.Update;

public record UpdateProductCommand(Guid Id, int QuantityInStock) : IRequest<Result<UpdateProductDTO>>
{
 
}
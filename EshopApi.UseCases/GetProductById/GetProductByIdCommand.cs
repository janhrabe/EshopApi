using EshopApi.Core;
using MediatR;

namespace EshopApi.UseCases.GetProductById;

public record GetProductByIdCommand(Guid Id) : IRequest<Result<Core.Entities.Product>>;
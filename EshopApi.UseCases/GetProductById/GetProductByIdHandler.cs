using EshopApi.Core;
using EshopApi.Core.Interfaces;
using MediatR;

namespace EshopApi.UseCases.GetProductById;

public class GetProductByIdHandler(IRepository<Core.Entities.Product> repository) : IRequestHandler<GetProductByIdCommand, Result<Core.Entities.Product>>
{
    public async Task<Result<Core.Entities.Product>> Handle(GetProductByIdCommand request,
        CancellationToken cancellationToken = default)
    {
        var result = await repository.GetByIdAsync(request.Id, cancellationToken);

        return result == null ? Result<Core.Entities.Product>.Failure("Product not found") : Result<Core.Entities.Product>.Success(result);
    }
}
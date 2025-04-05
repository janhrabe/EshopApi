using EshopApi.Core;
using EshopApi.Core.Interfaces;
using MediatR;
using ProductEntity = EshopApi.Core.Entities.Product;
namespace EshopApi.UseCases.Product.GetProductById;

public class GetProductByIdHandler(IRepository<ProductEntity> repository) : IRequestHandler<GetProductByIdCommand, Result<ProductEntity>>
{
    public async Task<Result<ProductEntity>> Handle(GetProductByIdCommand request,
        CancellationToken cancellationToken = default)
    {
        var result = await repository.GetByIdAsync(request.Id, cancellationToken);

        return result == null ? Result<ProductEntity>.Failure("Product not found") : Result<ProductEntity>.Success(result);
    }
}
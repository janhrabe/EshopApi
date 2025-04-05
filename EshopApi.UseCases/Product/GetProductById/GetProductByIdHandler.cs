using EshopApi.Core;
using EshopApi.Core.Interfaces;
using EshopApi.UseCases.Product.DTOs;
using MediatR;
using ProductEntity = EshopApi.Core.Entities.Product;
namespace EshopApi.UseCases.Product.GetProductById;

public class GetProductByIdHandler(IRepository<ProductEntity> repository) : IRequestHandler<GetProductByIdCommand, Result<ProductDto>>
{
    public async Task<Result<ProductDto>> Handle(GetProductByIdCommand request,
        CancellationToken cancellationToken = default)
    {
        var product = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (product == null)
        {
            return Result<ProductDto>.Failure("Product not found");
        }
        
        var dto = new ProductDto(
                product.Name,
                product.ImageUrl,
                product.Price,
                product.Description,
                product.QuantityInStock);
        
            return Result<ProductDto>.Success(dto);
    }
}
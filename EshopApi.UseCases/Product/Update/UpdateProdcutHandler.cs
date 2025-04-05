using EshopApi.Core;
using EshopApi.Core.Interfaces;
using EshopApi.UseCases.Product.DTOs;
using MediatR;
using ProductEntity = EshopApi.Core.Entities.Product;

namespace EshopApi.UseCases.Product.Update;

public class UpdateProductHandler(IRepository<ProductEntity> repository) : IRequestHandler<UpdateProductCommand, Result<UpdateProductDTO>>
{
    public async Task<Result<UpdateProductDTO>> Handle(UpdateProductCommand request,
        CancellationToken cancellationToken)
    {
       var productToUpdate = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (productToUpdate is null)
        {
            return Result<UpdateProductDTO>.NotFound();
        }
        
        productToUpdate.QuantityInStock = request.QuantityInStock;
        
        await repository.UpdateAsync(productToUpdate, cancellationToken);

        var dto = new UpdateProductDTO(
            productToUpdate.QuantityInStock
        );
        return Result<UpdateProductDTO>.Success(dto);
    }
}
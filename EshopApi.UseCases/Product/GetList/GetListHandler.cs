using EshopApi.Core;
using EshopApi.Core.Interfaces;
using EshopApi.UseCases.Product.DTOs;
using MediatR;
using ProductEntity = EshopApi.Core.Entities.Product;

namespace EshopApi.UseCases.Product.GetList;

public class GetListHandler(IRepository<ProductEntity> repository)
    : IRequestHandler<GetListCommand, Result<List<ListProductDto>>>
{
 

    public async Task<Result<List<ListProductDto>>> Handle(GetListCommand request, CancellationToken cancellationToken)
    {
        var allProducts = await repository.GetAllAsync(cancellationToken);
 
        var products = allProducts;
         
        var dtos = products.Select(p => new ListProductDto(
                p.Name,
                p.ImageUrl,
                p.Price,
                p.QuantityInStock))
            .ToList();

        return Result<List<ListProductDto>>.Success(dtos);
    }
}

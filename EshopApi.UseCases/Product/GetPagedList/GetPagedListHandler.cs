using EshopApi.Core;
using EshopApi.Core.Interfaces;
using EshopApi.UseCases.Product.DTOs;
using MediatR;
using ProductEntity = EshopApi.Core.Entities.Product;

namespace EshopApi.UseCases.Product.GetPagedList;

public class GetPagedListHandler(IRepository<ProductEntity> repository)
        : IRequestHandler<GetPagedListCommand, Result<List<ListProductDto>>> 
{
    private const int PageSize = 10;
    
    public async Task<Result<List<ListProductDto>>> Handle(GetPagedListCommand request, CancellationToken cancellationToken)
    {
        var allProducts = await repository.GetAllAsync(cancellationToken);

        var pageNumber = request.PageNumber ?? 1;
        var skip = (pageNumber - 1) * PageSize;

        var products = allProducts.Skip(skip).Take(PageSize);

        var dtos = products.Select(p => new ListProductDto(
            p.Name,
            p.ImageUrl,
            p.Price,
            p.QuantityInStock)).ToList();

        return Result<List<ListProductDto>>.Success(dtos);
    }
}



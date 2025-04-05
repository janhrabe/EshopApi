using EshopApi.Core;
using EshopApi.Core.Interfaces;
using EshopApi.UseCases.Product.DTOs;
using MediatR;
using ProductEntity = EshopApi.Core.Entities.Product;

namespace EshopApi.UseCases.Product.GetPagedList;

public class GetPagedListHandler(IRepository<ProductEntity> repository) : IRequestHandler<GetPagedListCommand, Result<List<ListProductDto>>>
{
    public async Task<Result<List<ListProductDto>>> Handle(GetPagedListCommand request,
        CancellationToken cancellationToken)
    {
        var all = await repository.GetAllAsync(cancellationToken);
        
        var pagedList = all
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .Select(p => new ListProductDto(
                p.Name,
                p.ImageUrl,
                p.Price,
                p.QuantityInStock))
            .ToList();
        
        return Result<List<ListProductDto>>.Success(pagedList);
    }
}
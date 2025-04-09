using EshopApi.UseCases.Product.DTOs;
using EshopApi.UseCases.Product.GetPagedList;
using FastEndpoints;
using MediatR;

namespace EshopAPi.Api.ProductEndpoints.PagedListEndpoint;

public class PagedListProductsEndpoint(IMediator mediator)
    : Endpoint<PagedListProductsRequest, PagedListProductsResponse>
{

    public override void Configure()
    {
        Get("/products/list");
        Version(1);
        AllowAnonymous();
    }

    public override async Task HandleAsync(PagedListProductsRequest request, CancellationToken cancellationToken)
    {
        var command = new GetPagedListCommand(request.PageNumber);

        var result = await mediator.Send(command, cancellationToken);

        if (result.IsSuccess)
        {
            Response = new PagedListProductsResponse
            {
                Products = result.Value!
                    .Select(p => new ListProductDto(p.Name, p.ImageUrl, p.Price, p.QuantityInStock))
                    .ToList()
            };

        }
        else
        {
            Response = new PagedListProductsResponse { Products = new List<ListProductDto>() };
        }
    }
}
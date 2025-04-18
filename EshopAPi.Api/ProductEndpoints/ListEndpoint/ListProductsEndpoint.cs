using EshopApi.UseCases.Product.DTOs;
using EshopApi.UseCases.Product.GetList;
using FastEndpoints;
using MediatR;

namespace EshopAPi.Api.ProductEndpoints.ListEndpoint;

public class ListProductsEndpoint(IMediator mediator) : EndpointWithoutRequest<ListProductsResponse>
{
    public override void Configure()
    {
        Get("/products/list");
        Version(0);
        AllowAnonymous();
    }

    public override async Task HandleAsync( CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetListCommand(), cancellationToken);

            if (result.IsSuccess)
            {
                Response = new ListProductsResponse
                {
                    Products = result.Value!
                        .Select(p => new ListProductDto(p.Name, p.ImageUrl, p.Price, p.QuantityInStock))
                        .ToList()
                };
            }
            else
            {
                Response = new ListProductsResponse { Products = new List<ListProductDto>() };
            }
        
    }
}
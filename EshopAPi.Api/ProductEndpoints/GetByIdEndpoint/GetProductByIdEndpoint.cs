using EshopApi.UseCases.Product.DTOs;
using EshopApi.UseCases.Product.GetProductById;
using FastEndpoints;
using MediatR;

namespace EshopAPi.Api.ProductEndpoints.GetByIdEndpoint;

public class GetProductByIdEndpoint(IMediator mediator) : Endpoint<GetProductByIdRequest, ProductDto>
{
    public override void Configure()
    {
        Get("/products/detail/{productId}");
        Version(0);
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetProductByIdRequest request, CancellationToken cancellationToken)
    {
        var command = new GetProductByIdCommand(request.ProductId);

        var result = await mediator.Send(command, cancellationToken);

        if (!result.IsSuccess || result.Value == null)
        {
            await SendAsync(null!, 400, cancellationToken);
            return;
        }

        Response = new ProductDto(
            result.Value.Name,
            result.Value.ImageUrl,
            result.Value.Price,
            result.Value.Description,
            result.Value.QuantityInStock);
    }
}
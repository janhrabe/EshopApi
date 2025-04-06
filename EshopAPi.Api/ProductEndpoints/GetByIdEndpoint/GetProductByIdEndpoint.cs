using EshopApi.UseCases.Product.DTOs;
using EshopApi.UseCases.Product.GetProductById;
using FastEndpoints;
using MediatR;

namespace EshopAPi.Api.ProductEndpoints.GetByIdEndpoint;

public class GetProductByIdEndpoint(Mediator mediator) : Endpoint<GetProductByIdRequest, ProductDto>
{
    public override void Configure()
    {
        Get("/products/{productId}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetProductByIdRequest request, CancellationToken cancellationToken)
    {
        var command = new GetProductByIdCommand(request.ProductId);

        var result = await mediator.Send(command, cancellationToken);

        if (!result.IsSuccess || result.Value == null)
        {
            await SendNotFoundAsync(cancellationToken);
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
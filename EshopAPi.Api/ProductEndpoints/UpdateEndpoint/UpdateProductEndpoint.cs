using EshopApi.UseCases.Product.DTOs;
using EshopApi.UseCases.Product.GetProductById;
using EshopApi.UseCases.Product.Update;
using FastEndpoints;
using MediatR;

namespace EshopAPi.Api.ProductEndpoints.UpdateEndpoint;

public class UpdateProductEndpoint(IMediator mediator) : Endpoint<UpdateProductRequest, UpdateProductResponse>
{
    public override void Configure()
    {
        Put("/products/update/{productId}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(UpdateProductRequest request, CancellationToken cancellationToken)
    {
        
        var result = await mediator.Send(
            new UpdateProductCommand(
                request.Id,
                request.QuantityInStock), 
            cancellationToken);

        if (!result.IsSuccess)
        {
            await SendNotFoundAsync(cancellationToken);
            return;
        }

        var command = new GetProductByIdCommand(request.Id);
        var commandResult = await mediator.Send(command, cancellationToken);

        if (!commandResult.IsSuccess || commandResult.ErrorMessage == "Not found!")
        {
            await SendNotFoundAsync(cancellationToken);
            return;
        }
        
        if (commandResult.IsSuccess)
        {
             var dto = commandResult.Value;
             Response = new UpdateProductResponse(
                 new UpdateProductDTO(
                     dto!.QuantityInStock
                 )
             );
        }
    }
}
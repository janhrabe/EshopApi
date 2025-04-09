using EshopApi.UseCases.Product.Create;
using FastEndpoints;
using MediatR;

namespace EshopAPi.Api.ProductEndpoints.CreateEndpoint;

public class CreateProductEndpoint(IMediator mediator) : Endpoint<CreateProductRequest, CreateProductResponse>
{
    
    public override void Configure()
    {
        Post("/products/create");
        Version(0);
        AllowAnonymous();
        Summary(s =>
        {
            s.ExampleRequest = new CreateProductRequest
            {
                Name = "New Product",
                ImageUrl = "images/products/new.png",
                Price = 100,
                Description = "Product description",
                QuantityInStock = 0,
            };
        });
    }

    public override async Task HandleAsync(CreateProductRequest request, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new CreateProductCommand(
            request.Name,
            request.ImageUrl,
            request.Price,
            request.Description,
            request.QuantityInStock), cancellationToken);

        if (result.IsSuccess)
        {
            Response = new CreateProductResponse(result.Value);
            return;
        }
        
        Response = new CreateProductResponse("Failed to create product");
    }
}
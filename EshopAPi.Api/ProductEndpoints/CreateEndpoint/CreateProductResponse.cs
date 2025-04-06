namespace EshopAPi.Api.ProductEndpoints.CreateEndpoint;

public class CreateProductResponse
{
    public Guid Id { get; set; }
    
    public string Message { get; set; }

    public CreateProductResponse(Guid productId)
    {
        Id = productId;
        Message = "Product created";
    }

    public CreateProductResponse(string message)
    {
        Id = Guid.Empty;
        Message = message;
    }
}
using Microsoft.AspNetCore.Mvc;

namespace EshopAPi.Api.ProductEndpoints.GetByIdEndpoint;

public class GetProductByIdRequest
{
    [FromRoute]
    public Guid ProductId { get; set; }
}
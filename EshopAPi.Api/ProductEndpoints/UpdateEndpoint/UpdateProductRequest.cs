using FastEndpoints;
using Microsoft.AspNetCore.Mvc;

namespace EshopAPi.Api.ProductEndpoints.UpdateEndpoint;

public class UpdateProductRequest
{
    [FromRoute]
    public Guid Id { get; set; }
    public int QuantityInStock { get; set; }
}
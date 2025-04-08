using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;

namespace EshopAPi.Api.ProductEndpoints.UpdateEndpoint;

public class UpdateProductRequest
{
    [JsonIgnore]
    [FromRoute]
    public Guid Id { get; set; }
    public int QuantityInStock { get; set; }
}
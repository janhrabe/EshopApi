using EshopApi.UseCases.Product.DTOs;

namespace EshopAPi.Api.ProductEndpoints.ListEndpoint;

public class ListProductsResponse
{
    public required IEnumerable<ListProductDto> Products { get; set; }
}
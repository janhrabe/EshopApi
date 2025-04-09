using EshopApi.UseCases.Product.DTOs;

namespace EshopAPi.Api.ProductEndpoints.PagedListEndpoint;

public class PagedListProductsResponse
{
    public required IEnumerable<ListProductDto> Products { get; set; }
}
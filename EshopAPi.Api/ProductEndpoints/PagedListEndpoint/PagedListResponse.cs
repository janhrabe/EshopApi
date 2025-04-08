using EshopApi.UseCases.Product.DTOs;

namespace EshopAPi.Api.ProductEndpoints.PagedListEndpoint;

public class PagedListResponse
{
    public required IEnumerable<ListProductDto> Products { get; set; }
}
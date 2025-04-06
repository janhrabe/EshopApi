using EshopApi.UseCases.Product.DTOs;

namespace EshopAPi.Api.ProductEndpoints.UpdateEndpoint;

public class UpdateProductResponse(UpdateProductDTO product)
{
    public UpdateProductDTO Product { get; set; } = product;
}
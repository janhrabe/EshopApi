using EshopApi.Core;
using EshopApi.Core.Interfaces;
using MediatR;

namespace EshopApi.UseCases.Product.Create;

public class CreateProductHandler(IRepository<Core.Entities.Product> repository) : IRequestHandler<CreateProductCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request.Name))
        {
            return Result<Guid>.Failure("Name is required");
        }

        if (string.IsNullOrEmpty(request.ImageUrl))
        {
            return Result<Guid>.Failure("ImageUrl is required");
        }

        var product = new Core.Entities.Product
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            ImageUrl = request.ImageUrl,
            Price = request.Price,
            Description = request.Description,
            QuantityInStock = request.QuantityInStock,
        };
        
        await repository.AddAsync(product, cancellationToken);
        
        return Result<Guid>.Success(product.Id);
    }
}
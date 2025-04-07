using Moq;
using EshopApi.UseCases.Product.GetList;
using EshopApi.UseCases.Product.GetProductById;
using EshopApi.UseCases.Product.Create;
using EshopApi.UseCases.Product.DTOs;
using MediatR;
using EshopAPi.Api.ProductEndpoints.CreateEndpoint;
using EshopAPi.Api.ProductEndpoints.GetByIdEndpoint;
using EshopAPi.Api.ProductEndpoints.UpdateEndpoint;
using EshopApi.Core;
using EshopApi.Core.Entities;
using EshopApi.Core.Interfaces;
using EshopApi.UseCases.Product.Update;

namespace EshopApi.Tests;

public class ProductEndpointsTests
{
    private readonly Mock<IMediator> _mediatorMock;
    private readonly Mock<IRepository<Product>> _repositoryMock;
    private readonly GetListHandler _handler;
    private List<Product> _seededProducts;

    public ProductEndpointsTests()
    {
        _mediatorMock = new Mock<IMediator>();
        _repositoryMock = new Mock<IRepository<Product>>();
        _handler = new GetListHandler(_repositoryMock.Object);
        SeedProducts();
    }

    private void SeedProducts()
    {
        _seededProducts =
        [
            new Product
            {
                Id = Guid.NewGuid(), Name = "Product 1", ImageUrl = "http://image.com/img1.jpg", Price = 10.99m,
                Description = "Description for Product 1", QuantityInStock = 5
            },
            new Product
            {
                Id = Guid.NewGuid(), Name = "Product 2", ImageUrl = "http://image.com/img2.jpg", Price = 20.99m,
                Description = "Description for Product 2", QuantityInStock = 10
            },
            new Product
            {
                Id = Guid.NewGuid(), Name = "Product 3", ImageUrl = "http://image.com/img3.jpg", Price = 30.99m,
                Description = "Description for Product 3", QuantityInStock = 15
            },
            new Product
            {
                Id = Guid.NewGuid(), Name = "Product 4", ImageUrl = "http://image.com/img4.jpg", Price = 40.99m,
                Description = "Description for Product 4", QuantityInStock = 20
            },
            new Product
            {
                Id = Guid.NewGuid(), Name = "Product 5", ImageUrl = "http://image.com/img5.jpg", Price = 50.99m,
                Description = "Description for Product 5", QuantityInStock = 25
            },
            new Product
            {
                Id = Guid.NewGuid(), Name = "Product 6", ImageUrl = "http://image.com/img6.jpg", Price = 60.99m,
                Description = "Description for Product 6", QuantityInStock = 30
            },
            new Product
            {
                Id = Guid.NewGuid(), Name = "Product 7", ImageUrl = "http://image.com/img7.jpg", Price = 70.99m,
                Description = "Description for Product 7", QuantityInStock = 35
            },
            new Product
            {
                Id = Guid.NewGuid(), Name = "Product 8", ImageUrl = "http://image.com/img8.jpg", Price = 80.99m,
                Description = "Description for Product 8", QuantityInStock = 40
            },
            new Product
            {
                Id = Guid.NewGuid(), Name = "Product 9", ImageUrl = "http://image.com/img9.jpg", Price = 90.99m,
                Description = "Description for Product 9", QuantityInStock = 45
            },
            new Product
            {
                Id = Guid.NewGuid(), Name = "Product 10", ImageUrl = "http://image.com/img10.jpg", Price = 100.99m,
                Description = "Description for Product 10", QuantityInStock = 50
            },
            new Product
            {
                Id = Guid.NewGuid(), Name = "Product 11", ImageUrl = "http://image.com/img11.jpg", Price = 110.99m,
                Description = "Description for Product 11", QuantityInStock = 55
            },
            new Product
            {
                Id = Guid.NewGuid(), Name = "Product 12", ImageUrl = "http://image.com/img12.jpg", Price = 120.99m,
                Description = "Description for Product 12", QuantityInStock = 60
            },
            new Product
            {
                Id = Guid.NewGuid(), Name = "Product 13", ImageUrl = "http://image.com/img13.jpg", Price = 130.99m,
                Description = "Description for Product 13", QuantityInStock = 65
            },
            new Product
            {
                Id = Guid.NewGuid(), Name = "Product 14", ImageUrl = "http://image.com/img14.jpg", Price = 140.99m,
                Description = "Description for Product 14", QuantityInStock = 70
            },
            new Product
            {
                Id = Guid.NewGuid(), Name = "Product 15", ImageUrl = "http://image.com/img15.jpg", Price = 150.99m,
                Description = "Description for Product 15", QuantityInStock = 75
            },
            new Product
            {
                Id = Guid.NewGuid(), Name = "Product 16", ImageUrl = "http://image.com/img16.jpg", Price = 160.99m,
                Description = "Description for Product 16", QuantityInStock = 80
            },
            new Product
            {
                Id = Guid.NewGuid(), Name = "Product 17", ImageUrl = "http://image.com/img17.jpg", Price = 170.99m,
                Description = "Description for Product 17", QuantityInStock = 85
            },
            new Product
            {
                Id = Guid.NewGuid(), Name = "Product 18", ImageUrl = "http://image.com/img18.jpg", Price = 180.99m,
                Description = "Description for Product 18", QuantityInStock = 90
            },
            new Product
            {
                Id = Guid.NewGuid(), Name = "Product 19", ImageUrl = "http://image.com/img19.jpg", Price = 190.99m,
                Description = "Description for Product 19", QuantityInStock = 95
            },
            new Product
            {
                Id = Guid.NewGuid(), Name = "Product 20", ImageUrl = "http://image.com/img20.jpg", Price = 200.99m,
                Description = "Description for Product 20", QuantityInStock = 100
            }
        ];
    }

    [Fact]
    public async Task Handle_ReturnsAllProducts_WhenPageNumberIsNull()
    {
        _repositoryMock.Setup(r => r.GetAllAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(_seededProducts);

        var command = new GetListCommand(null);
        var result = await _handler.Handle(command, CancellationToken.None);

        Assert.True(result.IsSuccess);
        Assert.Equal(20, result.Value!.Count); 
    }

    [Fact]
    public async Task Handle_ReturnsPagedProducts_WhenPageNumberIsProvided()
    {
        _repositoryMock.Setup(r => r.GetAllAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(_seededProducts);

        var command = new GetListCommand(2); 
        var result = await _handler.Handle(command, CancellationToken.None);

        Assert.True(result.IsSuccess);
        Assert.Equal(10, result.Value!.Count); 
        Assert.Equal("Product 11", result.Value.First().Name);
    }

    [Fact]
    public async Task Handle_MapsCorrectlyToDto()
    {
        var product = new Product
        {
            Name = "Test",
            ImageUrl = "http://image.com/img.jpg",
            Price = 99.99m,
            Description = "Test description",
            QuantityInStock = 5
        };

        _repositoryMock.Setup(r => r.GetAllAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(new List<Product> { product });

        var command = new GetListCommand(null);
        var result = await _handler.Handle(command, CancellationToken.None);

        var dto = result.Value!.First();
        Assert.Equal("Test", dto.Name);
        Assert.Equal("http://image.com/img.jpg", dto.ImageUrl);
        Assert.Equal(99.99m, dto.Price);
        Assert.Equal(5, dto.QuantityInStock);
    }

    [Fact]
    public async Task Handle_ReturnsEmptyList_WhenNoProducts()
    {
        _repositoryMock.Setup(r => r.GetAllAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(new List<Product>());

        var command = new GetListCommand(null);
        var result = await _handler.Handle(command, CancellationToken.None);

        Assert.True(result.IsSuccess);
        Assert.Empty(result.Value!);
    }

    [Fact]
    public async Task GetProductById_ReturnsProduct_WhenExists()
    {
        var product = new ProductDto("Test", "url", 49.99m, "desc", 5);

        _mediatorMock
            .Setup(m => m.Send(It.IsAny<GetProductByIdCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(Result<ProductDto>.Success(product));

        var endpoint = new GetProductByIdEndpoint(_mediatorMock.Object);
        var request = new GetProductByIdRequest { ProductId = Guid.NewGuid() };

        await endpoint.HandleAsync(request, CancellationToken.None);

        Assert.NotNull(endpoint.Response);
        Assert.Equal("Test", endpoint.Response.Name);
    }

    [Fact]
    public async Task CreateProduct_ReturnsCreatedProduct_WhenSuccessful()
    {
        var createdProductId = Guid.NewGuid();

        var productDto = new ProductDto("New Product", "url", 123.45m, "desc", 99);
        
        _mediatorMock
                .Setup(m => m.Send(It.IsAny<CreateProductCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(Result<Guid>.Success(createdProductId));

        _mediatorMock
            .Setup(m => m.Send(It.IsAny<GetProductByIdCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(Result<ProductDto>.Success(productDto));

        var endpoint = new CreateProductEndpoint(_mediatorMock.Object);
        
        var request = new CreateProductRequest 
        {
            Name = "New Product",
            Description = "desc", 
            ImageUrl = "url", 
            Price = 123.45m, 
            QuantityInStock = 99
        };
        
        await endpoint.HandleAsync(request, CancellationToken.None);
        
        Assert.NotNull(endpoint.Response); 
        Assert.Equal(createdProductId, endpoint.Response.Id); 
        Assert.Equal("Product created", endpoint.Response.Message);
    }
}

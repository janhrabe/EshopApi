using Moq;
using EshopApi.UseCases.Product.GetList;
using EshopApi.UseCases.Product.GetProductById;
using EshopApi.UseCases.Product.Create;
using EshopApi.UseCases.Product.DTOs;
using MediatR;
using EshopAPi.Api.ProductEndpoints.CreateEndpoint;
using EshopAPi.Api.ProductEndpoints.GetByIdEndpoint;
using EshopAPi.Api.ProductEndpoints.ListEndpoint;
using EshopAPi.Api.ProductEndpoints.PagedListEndpoint;
using EshopAPi.Api.ProductEndpoints.UpdateEndpoint;
using EshopApi.Core;
using EshopApi.Core.Entities;
using EshopApi.UseCases.Product.GetPagedList;
using EshopApi.UseCases.Product.Update;

namespace EshopApi.Tests;

public class ProductEndpointsTests
{
    private readonly Mock<IMediator> _mediatorMock;
    private List<Product> _seededProducts;

    public ProductEndpointsTests()
    {
        _mediatorMock = new Mock<IMediator>();
        SeedProducts();
    }

    private void SeedProducts()
    {
        _seededProducts = Enumerable.Range(1, 20).Select(i => new Product
        {
            Id = Guid.NewGuid(),
            Name = $"Product {i}",
            ImageUrl = $"http://image.com/img{i}.jpg",
            Price = 10.99m * i,
            Description = $"Description for Product {i}",
            QuantityInStock = 5 * i
        }).ToList();
    }

    [Fact]
    public async Task GetList_ReturnsAllProducts()
    {
        _mediatorMock.Setup(m => m.Send(It.IsAny<GetListCommand>(),It.IsAny<CancellationToken>()))
            .ReturnsAsync(Result<List<ListProductDto>>.Success(_seededProducts.Select(p =>
                new ListProductDto(p.Name, p.ImageUrl, p.Price, p.QuantityInStock)).ToList()));

        var endpoint = new ListProductsEndpoint(_mediatorMock.Object);
      

        await endpoint.HandleAsync(CancellationToken.None);

        Assert.NotNull(endpoint.Response);
        Assert.Equal(20, endpoint.Response.Products.Count());
    }
    

    [Fact]
    public async Task GetList_MapsCorrectlyToDto()
    {
        var product = new Product
        {
            Name = "Test",
            ImageUrl = "http://image.com/img.jpg",
            Price = 99.99m,
            Description = "Test description",
            QuantityInStock = 5
        };

        _mediatorMock.Setup(m => m.Send(It.IsAny<GetListCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(Result<List<ListProductDto>>.Success([
                new ListProductDto(product.Name, product.ImageUrl, product.Price, product.QuantityInStock)
            ]));

        var endpoint = new ListProductsEndpoint(_mediatorMock.Object);
     

        await endpoint.HandleAsync(CancellationToken.None);

        var dto = endpoint.Response.Products.First();
        Assert.True(dto.Name == "Test");
        Assert.True(dto.ImageUrl == "http://image.com/img.jpg");
        Assert.Equal(99.99m, dto.Price);
        Assert.Equal(5, dto.QuantityInStock);
    }

    [Fact]
    public async Task GetList_ReturnsEmptyList_WhenNoProducts()
    {
        _mediatorMock.Setup(m => m.Send(It.IsAny<GetListCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(Result<List<ListProductDto>>.Success(new List<ListProductDto>()));

        var endpoint = new ListProductsEndpoint(_mediatorMock.Object);
     

        await endpoint.HandleAsync(CancellationToken.None);

        Assert.NotNull(endpoint.Response);
        Assert.Empty(endpoint.Response.Products);
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
    
    [Fact]
    public async Task HandleAsync_UpdatesProductSuccessfully_ReturnsUpdatedResponse()
    {
        var request = new UpdateProductRequest
        {
            Id = Guid.NewGuid(),
            QuantityInStock = 15
        };

        var updatedDto = new ProductDto(
            "ProductName",
            "http://image.jpg",
            100.0m,
            "desc",
            request.QuantityInStock);

        _mediatorMock.Setup(m => m.Send(It.IsAny<UpdateProductCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(Result<UpdateProductDTO>.Success(new UpdateProductDTO(request.QuantityInStock)));

        _mediatorMock.Setup(m => m.Send(It.IsAny<GetProductByIdCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(Result<ProductDto>.Success(updatedDto));
        
        var endpoint = new UpdateProductEndpoint(_mediatorMock.Object);

        await endpoint.HandleAsync(request, CancellationToken.None);

        Assert.NotNull(endpoint.Response);
        Assert.Equal(request.QuantityInStock, endpoint.Response.Product.QuantityInStock);
    }
    
    [Fact]
    public async Task PagedList_ReturnsEmptyList_WhenNoProducts()
    {
       
        var command = new GetPagedListCommand(1);
        _mediatorMock.Setup(m => m.Send(command, It.IsAny<CancellationToken>()))
            .ReturnsAsync(Result<List<ListProductDto>>.Success(new List<ListProductDto>()));

        var endpoint = new PagedListProductsEndpoint(_mediatorMock.Object);
        var request = new PagedListProductsRequest { PageNumber = 1 };

 
        await endpoint.HandleAsync(request, CancellationToken.None);

        
        Assert.NotNull(endpoint.Response); 
        Assert.Empty(endpoint.Response.Products);
    }
    
    [Fact]
    public async Task PagedList_ReturnsProducts_WhenSuccess()
    {
        var paged = _seededProducts.Skip(10).Take(10).Select(p =>
            new ListProductDto(p.Name, p.ImageUrl, p.Price, p.QuantityInStock)).ToList();
        
        ///var command = new GetPagedListCommand(2);
        
        _mediatorMock.Setup(m => m.Send(It.Is<GetPagedListCommand>(c => c.PageNumber == 1), It.IsAny<CancellationToken>()))
            .ReturnsAsync(Result<List<ListProductDto>>.Success(paged));

        var endpoint = new PagedListProductsEndpoint(_mediatorMock.Object);
        var request = new PagedListProductsRequest { PageNumber = 1 };

        
        await endpoint.HandleAsync(request, CancellationToken.None);

      
        Assert.NotNull(endpoint.Response);
        Assert.Equal(10, endpoint.Response.Products.Count()); 
        Assert.Equal("Product 11", endpoint.Response.Products.First().Name);
    }

}

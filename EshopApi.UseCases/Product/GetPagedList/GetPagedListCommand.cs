using EshopApi.Core;
using EshopApi.UseCases.Product.DTOs;
using MediatR;

namespace EshopApi.UseCases.Product.GetPagedList;

public record GetPagedListCommand(int PageNumber = 1, int PageSize = 10) : IRequest<Result<List<ListProductDto>>>;
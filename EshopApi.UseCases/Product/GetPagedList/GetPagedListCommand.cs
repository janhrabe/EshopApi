using EshopApi.Core;
using EshopApi.UseCases.Product.DTOs;
using MediatR;

namespace EshopApi.UseCases.Product.GetPagedList;

public record GetPagedListCommand(int? PageNumber) : IRequest<Result<List<ListProductDto>>>;

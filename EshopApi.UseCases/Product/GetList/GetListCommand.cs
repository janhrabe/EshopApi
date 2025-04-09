using EshopApi.Core;
using EshopApi.UseCases.Product.DTOs;
using MediatR;

namespace EshopApi.UseCases.Product.GetList;

public record GetListCommand() : IRequest<Result<List<ListProductDto>>>;

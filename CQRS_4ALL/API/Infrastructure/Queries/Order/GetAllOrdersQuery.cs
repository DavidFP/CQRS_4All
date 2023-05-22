using System;
using MediatR;
using API.Application.Dtos;
namespace API.Infrastructure.Queries.Order
{
	public record GetAllOrdersQuery(): IRequest<List<OrderDto>>;
}


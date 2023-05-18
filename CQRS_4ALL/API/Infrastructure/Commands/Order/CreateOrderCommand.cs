using API.Application.Dtos;
using MediatR;
namespace API.Infrastructure.Commands.Order
{
	public record CreateOrderCommand():IRequest<OrderDto>;
}


using API.Application.Dtos;
using MediatR;
namespace API.Infrastructure.Commands.Order
{
    public record UpdateOrderCommand(OrderDto orderDto) : IRequest<OrderDto>;
}


using MediatR;
namespace API.Infrastructure.Commands.Order
{
    public record DeleteOrderCommand(int id) : IRequest<bool>;
}


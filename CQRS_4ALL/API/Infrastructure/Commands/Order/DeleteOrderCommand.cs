using MediatR;
namespace API.Infrastructure.Commands.Order
{
	public record DeleteOrderCommand(): IRequest<bool>;	
}


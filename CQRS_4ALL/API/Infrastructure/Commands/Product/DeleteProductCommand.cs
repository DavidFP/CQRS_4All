using MediatR;
namespace API.Infrastructure.Commands.Product
{
	public record DeleteProductCommand():IRequest<bool>;
}


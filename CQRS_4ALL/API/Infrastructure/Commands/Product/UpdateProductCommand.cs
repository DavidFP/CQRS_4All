using MediatR;
using API.Application.Dtos;
namespace API.Infrastructure.Commands.Product
{
	public record UpdateProductCommand():IRequest<ProductDto>;
}


using API.Application.Dtos;
using MediatR;
namespace API.Infrastructure.Commands.Product
{
	public record CreateProductCommand():IRequest<ProductDto>;
	
}
using MediatR;
using API.Application.Dtos;
namespace API.Infrastructure.Queries.Product
{
	public record GetProductById(int id):IRequest<ProductDto>;
}
using MediatR;
using API.Application.Dtos;
namespace API.Infrastructure.Queries.Product
{
	public record GetAllProductsQuery():IRequest<IList<ProductDto>>;
}


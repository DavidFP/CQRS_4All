using MediatR;
using API.Infrastructure.Queries.Order;
using API.Data;
using API.Application.Dtos;
using Microsoft.EntityFrameworkCore;

namespace API;
public class GeAllOrderHandler : IRequestHandler<GetAllOrdersQuery, List<OrderDto>>
{
    private readonly ApplicationDbContext _db;

    public GeAllOrderHandler(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<List<OrderDto>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
    {
        var result = await _db.Orders.AsNoTracking()
                              .Select(o => new OrderDto(
                                  o.Id,
                                  o.Name,
                                  o.Address
                              )).ToListAsync<OrderDto>();
        return result;
    }
}

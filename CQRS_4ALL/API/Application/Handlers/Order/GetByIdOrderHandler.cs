using MediatR;
using API.Data;
using API.Infrastructure.Queries.Order;
using API.Application.Dtos;

namespace API;
public class GetByIdOrderHandler : IRequestHandler<GetOrderByIdQuery, OrderDto>
{
    private readonly ApplicationDbContext _db;

    public GetByIdOrderHandler(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<OrderDto> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        var order = await _db.Orders.FindAsync(request.id);
        return new OrderDto(order.Id, order.Name, order.Address);
    }
}


using API.Application.Dtos;
using API.Data;
using API.Domain.Entities;
using API.Infrastructure.Commands.Order;
using MediatR;

namespace API;
public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, OrderDto>
{
    private readonly ApplicationDbContext _db;
    public CreateOrderHandler(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<OrderDto> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
       var order = new Order();
       order.Name = request.orderDto.Name;
       order.Address = request.orderDto.Address;

       await _db.Orders.AddAsync(order);
       await _db.SaveChangesAsync();
       
       return request.orderDto;
    }
}

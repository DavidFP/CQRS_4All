using API.Application.Dtos;
using API.Data;
using API.Infrastructure.Commands.Order;
using MediatR;

namespace API;
public class UpdateOrderHandler : IRequestHandler<UpdateOrderCommand, OrderDto>
{
    private readonly ApplicationDbContext _db;

    public UpdateOrderHandler(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<OrderDto> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        var originalOrder = await _db.Orders.FindAsync(request.orderDto.Id);
        if (originalOrder != null)
        {
            originalOrder.Name = request.orderDto.Name;
            originalOrder.Address = request.orderDto.Address;
            originalOrder.UpdatedAt = DateTime.UtcNow;
            _db.Orders.Update(originalOrder);
            await _db.SaveChangesAsync();
        }
        return request.orderDto;
    }
}

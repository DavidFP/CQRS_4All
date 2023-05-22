using API.Data;
using API.Infrastructure.Commands.Order;
using MediatR;

namespace API;
public class DeleteOrderHandler : IRequestHandler<DeleteOrderCommand, bool>
{
    private readonly ApplicationDbContext _db;

    public DeleteOrderHandler(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<bool> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        var entityToRemove = await _db.Orders.FindAsync(request.id);
        if (entityToRemove != null)
        {
            var result = _db.Orders.Remove(entityToRemove);
            if (result != null)
            {
                await _db.SaveChangesAsync();
                return true;
            }
        }
        return false;
    }
}

using FONdrum.Domain.Models;
using FONdrum.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FONdrum.DataAccess.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly DbSet<Order> _orders;

    public OrderRepository(FONdrumContext context)
    {
        _orders = context.Orders;
    }

    public async Task<Order?> FindByIdAndStatusAsync(Guid id, OrderStatus status, CancellationToken cancellationToken)
    {
        return await _orders
            .Where(o => o.Id == id && o.Status == status)
            .Include(o => o.Items)
            .ThenInclude(oi => oi.Wine)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task AddAsync(Order order, CancellationToken cancellationToken = default)
    {
        await _orders.AddAsync(order, cancellationToken);
    }
}

using FONdrum.Domain.Models;

namespace FONdrum.Domain.Repositories;

public interface IOrderRepository
{
    Task<Order?> FindByIdAndStatusAsync(Guid id, OrderStatus status, CancellationToken cancellationToken);
    Task AddAsync(Order order, CancellationToken cancellationToken);
}

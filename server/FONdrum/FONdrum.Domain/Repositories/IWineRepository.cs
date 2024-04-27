using FONdrum.Domain.Models;

namespace FONdrum.Domain.Repositories;

public interface IWineRepository
{
    Task<Wine?> FindByIdAsync(Guid id, CancellationToken cancellationToken);
}

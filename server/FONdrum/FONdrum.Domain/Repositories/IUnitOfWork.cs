namespace FONdrum.Domain.Repositories;

public interface IUnitOfWork
{
    Task SaveAsync(CancellationToken cancellationToken);
}

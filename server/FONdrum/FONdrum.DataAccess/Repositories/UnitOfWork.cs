using FONdrum.Domain.Repositories;

namespace FONdrum.DataAccess.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly FONdrumContext _context;

    public UnitOfWork(FONdrumContext context)
    {
        _context = context;
    }

    public async Task SaveAsync(CancellationToken cancellationToken = default)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}

using FONdrum.Domain.Models;
using FONdrum.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FONdrum.DataAccess.Repositories;

public class WineRepository : IWineRepository
{
    private readonly DbSet<Wine> _wines;

    public WineRepository(FONdrumContext context)
    {
        _wines = context.Wines;
    }

    public async Task<Wine?> FindByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _wines.FirstOrDefaultAsync(w => w.Id == id, cancellationToken);
    }
}

using BloodNetwork.Domain.Interfaces;
using BloodNetwork.Infrastructure.Data;

namespace BloodNetwork.Infrastructure.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly BloodNetworkDbContext _context;

    public UnitOfWork(BloodNetworkDbContext context)
    {
        _context = context;
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}

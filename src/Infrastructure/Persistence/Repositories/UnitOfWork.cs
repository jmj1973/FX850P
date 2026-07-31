using Domain.Persistence.Interfaces;

namespace Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDBContext _context;

    public UnitOfWork(ApplicationDBContext context) => _context = context;

    public Task<int> SaveAsync(CancellationToken cancellationToken) => _context.SaveChangesAsync(cancellationToken);
}

using System.Threading;
using System.Threading.Tasks;
using FX850P.Domain.Presistence.Interfaces;

namespace FX850P.Presistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDBContext _context;

    public UnitOfWork(ApplicationDBContext context) => _context = context;

    public Task<int> SaveAsync(CancellationToken cancellationToken) => _context.SaveChangesAsync(cancellationToken);
}

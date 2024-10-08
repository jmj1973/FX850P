using System.Threading;
using System.Threading.Tasks;
using FX850P.Domain.Presistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FX850P.Presistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly IDbContextFactory<ApplicationDBContext> _factory;

    public UnitOfWork(IDbContextFactory<ApplicationDBContext> factory) => _factory = factory;

    public Task<int> SaveAsync(CancellationToken cancellationToken)
    {
        using ApplicationDBContext context = _factory.CreateDbContext();
        return context.SaveChangesAsync(cancellationToken);
    }
}

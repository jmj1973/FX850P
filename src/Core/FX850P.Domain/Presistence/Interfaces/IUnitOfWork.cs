using System.Threading;
using System.Threading.Tasks;

namespace FX850P.Domain.Presistence.Interfaces;

public interface IUnitOfWork
{
    Task<int> SaveAsync(CancellationToken cancellationToken);
}

using System.Threading;
using System.Threading.Tasks;

namespace FX850P.Application.Mediator.Contracts;
public interface IApplicationMediator
{
    Task<TResponse> Send<TRequest, TResponse>(TRequest request, CancellationToken cancellationToken = default) where TRequest : IApplicationRequest<TResponse>;
}

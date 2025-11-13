using FX850P.Application.Mediator.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace FX850P.Application.Mediator;
public class ApplicationMediator : IApplicationMediator
{
    private readonly IServiceScopeFactory _scopeFactory;

    public ApplicationMediator(IServiceScopeFactory scopeFactory) => _scopeFactory = scopeFactory;


    public async Task<TResponse> Send<TRequest, TResponse>(TRequest request, CancellationToken cancellationToken = default) where TRequest : IApplicationRequest<TResponse>
    {
        using IServiceScope scope = _scopeFactory.CreateScope();
        IApplicationRequestHandler<TRequest, TResponse> handler = scope.ServiceProvider.GetRequiredService<IApplicationRequestHandler<TRequest, TResponse>>();
        return await handler.Handle(request, cancellationToken);
    }
}




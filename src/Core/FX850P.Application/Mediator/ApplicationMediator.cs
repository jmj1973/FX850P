using System;
using System.Threading;
using System.Threading.Tasks;
using FX850P.Application.Mediator.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace FX850P.Application.Mediator;
public class ApplicationMediator : IApplicationMediator
{
    private readonly IServiceProvider _serviceProvider;

    public ApplicationMediator(IServiceProvider serviceProvider) => _serviceProvider = serviceProvider;


    public async Task<TResponse> Send<TRequest, TResponse>(TRequest request, CancellationToken cancellationToken = default) where TRequest : IApplicationRequest<TResponse>
    {
        using IServiceScope scope = _serviceProvider.CreateScope();
        IApplicationRequestHandler<TRequest, TResponse> handler = scope.ServiceProvider.GetRequiredService<IApplicationRequestHandler<TRequest, TResponse>>();
        return await handler.Handle(request, cancellationToken);
    }
}




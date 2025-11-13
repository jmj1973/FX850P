namespace FX850P.Application.Mediator.Contracts;
public interface IApplicationRequestHandler<TRequest, TResponse>
    where TRequest : IApplicationRequest<TResponse>
{
    Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken = default);
}

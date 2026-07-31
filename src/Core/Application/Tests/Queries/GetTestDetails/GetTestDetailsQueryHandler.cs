//Paramter map for string format
// {0} <App>  
// {1} <Item> plural
// {2} <Item>
// {3} <Item> lowercase

using Application.Exceptions;
using Application.Tests.Dtos;
using Application.Mediator.Contracts;
using Domain.Persistence.Interfaces;

namespace Application.Tests.Queries.GetTestDetails;

public class GetTestDetailsQueryHandler : IApplicationRequestHandler<GetTestDetailsQuery, TestDto>
{
    private readonly ITestRepository _repository;

    public GetTestDetailsQueryHandler(ITestRepository repository) => _repository = repository;

    public async Task<TestDto> Handle(GetTestDetailsQuery request, CancellationToken cancellationToken = default)
    {
        Domain.Entities.Test? test = await _repository.FindUniqueAsync(u => u.Id == request.Id, cancellationToken);

        if (test is null)
        {
            throw new NotFoundException(nameof(test), request.Id);
        }

        return test.ToDto();
    }
}

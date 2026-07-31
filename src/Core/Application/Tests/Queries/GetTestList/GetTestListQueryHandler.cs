//Paramter map for string format
// {0} <App>  
// {1} <Item> plural
// {2} <Item>
// {3} <Item> lowercase

using Application.Common.Dtos;
using Application.Tests.Dtos;
using Domain.Resources;
using Application.Mediator.Contracts;
using Application.Common;
using Domain.Persistence.Interfaces;

namespace Application.Tests.Queries.GetTestList;

public class GetTestListQueryHandler : IApplicationRequestHandler<GetTestListQuery, QueryResultDto<TestDto>>
{
    private readonly ITestRepository _repository;

    public GetTestListQueryHandler(ITestRepository repository) => _repository = repository;

    public async Task<QueryResultDto<TestDto>> Handle(GetTestListQuery request, CancellationToken cancellationToken = default)
    {
        TestQuery query = request.ToEntity();
        Domain.Common.QueryResult<Domain.Entities.Test> queryResult = await _repository.GetPagedListAsync(query, cancellationToken);
        return queryResult.ToDto(TestMapper.ToDto);
    }
}

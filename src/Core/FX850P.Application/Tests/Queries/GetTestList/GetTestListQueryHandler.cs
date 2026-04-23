//Paramter map for string format
// {0} <App>  
// {1} <Item> plural
// {2} <Item>
// {3} <Item> lowercase

using FX850P.Application.Common.Dtos;
using FX850P.Application.Tests.Dtos;
using FX850P.Domain.Presistence.Interfaces;
using FX850P.Domain.Resources;
using FX850P.Application.Mediator.Contracts;
using FX850P.Application.Common;

namespace FX850P.Application.Tests.Queries.GetTestList;

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

//Paramter map for string format
// {0} <App>  
// {1} <Item> plural
// {2} <Item>
// {3} <Item> lowercase

using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using FX850P.Application.Common.Dtos;
using FX850P.Application.Tests.Dtos;
using FX850P.Domain.Presistence.Interfaces;
using FX850P.Domain.Resources;
using FX850P.Application.Mediator.Contracts;

namespace FX850P.Application.Tests.Queries.GetTestList;

public class GetTestListQueryHandler : IApplicationRequestHandler<GetTestListQuery, QueryResultDto<TestDto>>
{
    private readonly ITestRepository _repository;
    private readonly IMapper _mapper;

    public GetTestListQueryHandler(ITestRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<QueryResultDto<TestDto>> Handle(GetTestListQuery request, CancellationToken cancellationToken)
    {
        TestQuery query = _mapper.Map<TestQuery>(request);
        Domain.Common.QueryResult<Domain.Entities.Test> queryResult = await _repository.GetPagedListAsync(query, cancellationToken);
        return _mapper.Map<QueryResultDto<TestDto>>(queryResult);
    }
}

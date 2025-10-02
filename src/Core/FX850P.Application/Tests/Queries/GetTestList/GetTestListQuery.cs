//Paramter map for string format
// {0} <App>  
// {1} <Item> plural
// {2} <Item>
// {3} <Item> lowercase

using FX850P.Application.Common.Dtos;
using FX850P.Application.Mediator.Contracts;
using FX850P.Application.Tests.Dtos;
using FX850P.Domain.Presistence.Interfaces;

namespace FX850P.Application.Tests.Queries.GetTestList;

public class GetTestListQuery : IApplicationRequest<QueryResultDto<TestDto>>, IQueryObject
{
    public string SearchString { get; set; } = default!;
    public string SortBy { get; set; } = default!;
    public bool IsSortAscending { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; }
}

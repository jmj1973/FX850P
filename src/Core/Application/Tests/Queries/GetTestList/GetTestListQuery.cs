//Paramter map for string format
// {0} <App>  
// {1} <Item> plural
// {2} <Item>
// {3} <Item> lowercase

using Application.Common.Dtos;
using Application.Mediator.Contracts;
using Application.Tests.Dtos;
using Domain.Persistence.Interfaces;

namespace Application.Tests.Queries.GetTestList;

public class GetTestListQuery : IApplicationRequest<QueryResultDto<TestDto>>, IQueryObject
{
    public string SearchString { get; set; } = default!;
    public string SortBy { get; set; } = default!;
    public bool IsSortAscending { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; }
}

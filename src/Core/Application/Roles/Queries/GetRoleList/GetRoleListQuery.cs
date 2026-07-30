using Application.Common.Dtos;
using Application.Common.Dtos;
using Application.Mediator.Contracts;
using Domain.Presistence.Interfaces;

namespace Application.Roles.Queries.GetRoleList;

public class GetRoleListQuery : IApplicationRequest<QueryResultDto<KeyValuePairDto<string>>>, IQueryObject
{
    public string SearchString { get; set; } = default!;
    public string SortBy { get; set; } = default!;
    public bool IsSortAscending { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; }
}

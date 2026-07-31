using Application.Common.Dtos;
using Application.Mediator.Contracts;
using Application.Users.Dtos;
using Domain.Persistence.Interfaces;

namespace Application.Users.Queries.GetUserList;

public class GetUserListQuery : IApplicationRequest<QueryResultDto<UserDto>>, IQueryObject
{
    public string SearchString { get; set; } = default!;
    public string SortBy { get; set; } = default!;
    public bool IsSortAscending { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; }


}

using Application.Common;
using Application.Common.Dtos;
using Application.Mediator.Contracts;
using Application.Users.Dtos;
using Domain.Presistence.Interfaces;
using Domain.Resources;

namespace Application.Users.Queries.GetUserList;

public class GetUserListQueryHandler : IApplicationRequestHandler<GetUserListQuery, QueryResultDto<UserDto>>
{
    private readonly IUserService _userService;

    public GetUserListQueryHandler(IUserService userService) => _userService = userService;

    public async Task<QueryResultDto<UserDto>> Handle(GetUserListQuery request, CancellationToken cancellationToken = default)
    {
        UserQuery userQuery = request.ToEntity();
        Domain.Common.QueryResult<Domain.Entities.Identity.ApplicationUser> queryResult = await _userService.GetPagedListAsync(userQuery, cancellationToken);
        return queryResult.ToDto(UserMapper.ToDto);
    }
}

using FX850P.Application.Common;
using FX850P.Application.Common.Dtos;
using FX850P.Application.Mediator.Contracts;
using FX850P.Application.Users.Dtos;
using FX850P.Domain.Presistence.Interfaces;
using FX850P.Domain.Resources;

namespace FX850P.Application.Users.Queries.GetUserList;

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

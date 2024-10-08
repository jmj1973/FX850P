using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FX850P.Application.Common.Dtos;
using FX850P.Application.Users.Dtos;
using FX850P.Domain.Presistence.Interfaces;
using FX850P.Domain.Resources;
using MediatR;

namespace FX850P.Application.Users.Queries.GetUserList;

public class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, QueryResultDto<UserDto>>
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public GetUserListQueryHandler(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    public async Task<QueryResultDto<UserDto>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
    {
        UserQuery userQuery = _mapper.Map<UserQuery>(request);
        Domain.Common.QueryResult<Domain.Entities.Identity.ApplicationUser> queryResult = await _userService.GetPagedListAsync(userQuery, cancellationToken);
        return _mapper.Map<QueryResultDto<UserDto>>(queryResult);
    }
}

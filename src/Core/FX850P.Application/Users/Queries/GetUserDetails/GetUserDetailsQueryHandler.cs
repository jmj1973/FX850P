using AutoMapper;
using FX850P.Application.Exceptions;
using FX850P.Application.Mediator.Contracts;
using FX850P.Application.Users.Dtos;
using FX850P.Domain.Presistence.Interfaces;

namespace FX850P.Application.Users.Queries.GetUserDetails;

public class GetUserDetailsQueryHandler : IApplicationRequestHandler<GetUserDetailsQuery, UserDto>
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public GetUserDetailsQueryHandler(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    public async Task<UserDto> Handle(GetUserDetailsQuery request, CancellationToken cancellationToken = default)
    {
        Domain.Entities.Identity.ApplicationUser? user = await _userService.FindUniqueAsync(u => u.Id == request.Id, cancellationToken);

        if (user is null)
        {
            throw new NotFoundException(nameof(user), request.Id);
        }

        System.Collections.Generic.IList<string> roles = await _userService.GetUserRoles(user);

        string? role = roles.FirstOrDefault();

        UserDto returnUser = _mapper.Map<UserDto>(user);

        returnUser.Role = string.IsNullOrWhiteSpace(role) ? "User" : role;

        return returnUser;
    }
}

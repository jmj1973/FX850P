using Application.Exceptions;
using Application.Mediator.Contracts;
using Application.Users.Dtos;
using Domain.Persistence.Interfaces;

namespace Application.Users.Queries.GetUserDetails;

public class GetUserDetailsQueryHandler : IApplicationRequestHandler<GetUserDetailsQuery, UserDto>
{
    private readonly IUserService _userService;

    public GetUserDetailsQueryHandler(IUserService userService) => _userService = userService;

    public async Task<UserDto> Handle(GetUserDetailsQuery request, CancellationToken cancellationToken = default)
    {
        Domain.Entities.Identity.ApplicationUser? user = await _userService.FindUniqueAsync(u => u.Id == request.Id, cancellationToken);

        if (user is null)
        {
            throw new NotFoundException(nameof(user), request.Id);
        }

        System.Collections.Generic.IList<string> roles = await _userService.GetUserRoles(user);

        string? role = roles.FirstOrDefault();

        UserDto returnUser = user.ToDto();

        returnUser.Role = string.IsNullOrWhiteSpace(role) ? "User" : role;

        return returnUser;
    }
}

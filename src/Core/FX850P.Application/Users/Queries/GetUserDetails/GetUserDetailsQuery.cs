using FX850P.Application.Mediator.Contracts;
using FX850P.Application.Users.Dtos;

namespace FX850P.Application.Users.Queries.GetUserDetails;

public class GetUserDetailsQuery : IApplicationRequest<UserDto>
{
    public string Id { get; set; } = default!;
}

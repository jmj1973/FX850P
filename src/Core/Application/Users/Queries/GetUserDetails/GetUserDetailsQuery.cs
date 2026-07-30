using Application.Mediator.Contracts;
using Application.Users.Dtos;

namespace Application.Users.Queries.GetUserDetails;

public class GetUserDetailsQuery : IApplicationRequest<UserDto>
{
    public string Id { get; set; } = default!;
}

using FX850P.Application.Users.Dtos;
using MediatR;

namespace FX850P.Application.Users.Queries.GetUserDetails
{
    public class GetUserDetailsQuery : IRequest<UserDto>
    {
        public string Id { get; set; } = default!;
    }
}

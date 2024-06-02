using AutoMapper;
using FX850P.Application.Exceptions;
using FX850P.Application.Users.Dtos;
using FX850P.Domain.Presistence.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace FX850P.Application.Users.Queries.GetUserDetails
{
    public class GetUserDetailsQueryHandler : IRequestHandler<GetUserDetailsQuery, UserDto>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public GetUserDetailsQueryHandler(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(GetUserDetailsQuery request, CancellationToken cancellationToken)
        {
            var user = await _userService.FindUniqueAsync(u => u.Id == request.Id, cancellationToken);

            if (user is null)
            {
                throw new NotFoundException(nameof(user), request.Id);
            }

            var roles = await _userService.GetUserRoles(user);

            var role = roles.FirstOrDefault();

            var returnUser = _mapper.Map<UserDto>(user);

            returnUser.Role = string.IsNullOrWhiteSpace(role) ? "User" : role;

            return returnUser;
        }
    }
}

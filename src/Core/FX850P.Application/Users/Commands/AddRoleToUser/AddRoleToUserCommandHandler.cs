using AutoMapper;
using MediatR;
using FX850P.Application.Exceptions;
using FX850P.Application.Users.Commands.AddRoleUser;
using FX850P.Application.Users.Dtos;
using FX850P.Domain.Presistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace FX850P.Application.Users.Commands.AddRoleToUser
{
    public class AddRoleToUserCommandHandler : IRequestHandler<AddRoleToUserCommand, UserDto>
    {
        private readonly IUserService _userService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddRoleToUserCommandHandler(IUserService userService, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _userService = userService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(AddRoleToUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userService.FindUniqueAsync(u => u.Id == request.Id, cancellationToken);

            if (user is null)
            {
                throw new NotFoundException(nameof(user), request.Id);
            }

            //Remove old roles
            var roles = await _userService.GetUserRoles(user);
            foreach (var removeRole in roles)
            {
                await _userService.RemoveRoleFromUser(user, removeRole);
            }

            await _userService.AddRoleToUser(user, request.Role);

            var returnUser = _mapper.Map<UserDto>(user);
            returnUser.Role = request.Role;

            return returnUser;

        }
    }
}

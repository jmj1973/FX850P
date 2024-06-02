using AutoMapper;
using FX850P.Application.Exceptions;
using FX850P.Application.Users.Dtos;
using FX850P.Domain.Presistence.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FX850P.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UserDto>
    {
        private readonly IUserService _userService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(IUserService userService, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _userService = userService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            // Validation
            var validator = new UpdateUserCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult.Errors);

            // Check if exist
            var user = await _userService.FindUniqueAsync(u => u.Id == request.Id, cancellationToken);

            if (user is null)
            {
                throw new NotFoundException(nameof(user), request.Id);
            }

            _mapper.Map(request, user);

            await _userService.UpdateAsync(user);

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

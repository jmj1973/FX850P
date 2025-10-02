using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FX850P.Application.Exceptions;
using FX850P.Application.Mediator.Contracts;
using FX850P.Application.Users.Dtos;
using FX850P.Domain.Presistence.Interfaces;

namespace FX850P.Application.Users.Commands.UpdateUser;

public class UpdateUserCommandHandler : IApplicationRequestHandler<UpdateUserCommand, UserDto>
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
        FluentValidation.Results.ValidationResult validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (validationResult.IsValid == false)
        {
            throw new ValidationException(validationResult.Errors);
        }

        // Check if exist
        Domain.Entities.Identity.ApplicationUser? user = await _userService.FindUniqueAsync(u => u.Id == request.Id, cancellationToken);

        if (user is null)
        {
            throw new NotFoundException(nameof(user), request.Id);
        }

        _mapper.Map(request, user);

        await _userService.UpdateAsync(user);

        //Remove old roles
        System.Collections.Generic.IList<string> roles = await _userService.GetUserRoles(user);
        foreach (string removeRole in roles)
        {
            await _userService.RemoveRoleFromUser(user, removeRole);
        }

        await _userService.AddRoleToUser(user, request.Role);

        UserDto returnUser = _mapper.Map<UserDto>(user);
        returnUser.Role = request.Role;

        return returnUser;
    }
}

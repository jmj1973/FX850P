using Application.Exceptions;
using Application.Mediator.Contracts;
using Application.Users.Dtos;
using Domain.Persistence.Interfaces;

namespace Application.Users.Commands.UpdateUserPassword;

public class UpdateUserPasswordCommandHandler : IApplicationRequestHandler<UpdateUserPasswordCommand, UserDto>
{
    private readonly IUserService _userService;

    public UpdateUserPasswordCommandHandler(IUserService userService) => _userService = userService;

    public async Task<UserDto> Handle(UpdateUserPasswordCommand request, CancellationToken cancellationToken = default)
    {
        // Validate
        var validator = new UpdateUserPasswordCommandValidator();
        FluentValidation.Results.ValidationResult validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        // Check if exist
        Domain.Entities.Identity.ApplicationUser? user = await _userService.FindUniqueAsync(u => u.Id == request.Id, cancellationToken);

        if (user is null)
        {
            throw new NotFoundException(nameof(user), request.Id);
        }

        Domain.Common.ServiceResult serviceResult = await _userService.UpdatePasswordAsync(user, request.OldPassword, request.NewPassword);

        if (!serviceResult.IsValid)
        {
            throw new BadRequestException(serviceResult.Error);
        }

        return user.ToDto();
    }
}

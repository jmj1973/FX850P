﻿using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FX850P.Application.Exceptions;
using FX850P.Application.Users.Dtos;
using FX850P.Domain.Presistence.Interfaces;
using MediatR;

namespace FX850P.Application.Users.Commands.UpdateUserPassword;

public class UpdateUserPasswordCommandHandler : IRequestHandler<UpdateUserPasswordCommand, UserDto>
{
    private readonly IUserService _userService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateUserPasswordCommandHandler(IUserService userService, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _userService = userService;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<UserDto> Handle(UpdateUserPasswordCommand request, CancellationToken cancellationToken)
    {
        // Validate
        var validator = new UpdateUserPasswordCommandValidator();
        FluentValidation.Results.ValidationResult validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (validationResult.IsValid == false)
            throw new ValidationException(validationResult.Errors);

        // Check if exist
        Domain.Entities.Identity.ApplicationUser? user = await _userService.FindUniqueAsync(u => u.Id == request.Id, cancellationToken);

        if (user is null)
        {
            throw new NotFoundException(nameof(user), request.Id);
        }

        Domain.Common.ServiceResult serviceResult = await _userService.UpdatePasswordAsync(user, request.OldPassword, request.NewPassword);

        if (serviceResult.IsValid == false)
            throw new BadRequestException(serviceResult.Error);

        return _mapper.Map<UserDto>(user);
    }
}

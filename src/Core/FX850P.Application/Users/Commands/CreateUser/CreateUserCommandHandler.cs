using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FX850P.Application.Exceptions;
using FX850P.Application.Users.Dtos;
using FX850P.Domain.Entities.Identity;
using FX850P.Domain.Presistence.Interfaces;
using MediatR;

namespace FX850P.Application.Users.Commands.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserDto>
{
    private readonly IUserService _userService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateUserCommandHandler(IUserService userService, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _userService = userService;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        // Validate
        var validator = new CreateUserCommandValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (validationResult.IsValid == false)
            throw new ValidationException(validationResult.Errors);

        //Check if exist
        var existingUser = await _userService.ExistAsync(u => u.UserName.ToUpper() == request.UserName.ToUpper());

        if (existingUser)
        {
            throw new Exception($"Username '{request.UserName}' already exists.");
        }

        var existingEmail = await _userService.ExistAsync(u => u.Email.ToUpper() == request.Email.ToUpper());

        if (existingUser)
        {
            throw new Exception($"Email '{request.Email}' already exists.");
        }

        // Add User
        var user = new ApplicationUser
        {
            Email = request.Email,
            FirstName = request.FirstName,
            LastName = request.LastName,
            UserName = request.UserName,
            EmailConfirmed = true
        };

        await _userService.AddAsync(user, request.Password, request.Role);

        var returnUser = _mapper.Map<UserDto>(user);
        returnUser.Role = request.Role;

        return returnUser;
    }
}

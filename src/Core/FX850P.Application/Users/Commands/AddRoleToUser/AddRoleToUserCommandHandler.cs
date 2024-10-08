﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FX850P.Application.Exceptions;
using FX850P.Application.Users.Commands.AddRoleUser;
using FX850P.Application.Users.Dtos;
using FX850P.Domain.Presistence.Interfaces;
using MediatR;

namespace FX850P.Application.Users.Commands.AddRoleToUser;

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
        Domain.Entities.Identity.ApplicationUser? user = await _userService.FindUniqueAsync(u => u.Id == request.Id, cancellationToken);

        if (user is null)
        {
            throw new NotFoundException(nameof(user), request.Id);
        }

        //Remove old roles
        IList<string> roles = await _userService.GetUserRoles(user);
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

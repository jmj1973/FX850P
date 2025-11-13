using AutoMapper;
using FX850P.Application.Exceptions;
using FX850P.Application.Mediator.Contracts;
using FX850P.Application.Users.Dtos;
using FX850P.Domain.Presistence.Interfaces;

namespace FX850P.Application.Users.Commands.UnlockUser;

public class UnlockUserCommandHandler : IApplicationRequestHandler<UnlockUserCommand, UserDto>
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public UnlockUserCommandHandler(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    public async Task<UserDto> Handle(UnlockUserCommand request, CancellationToken cancellationToken = default)
    {
        // Check if exist
        Domain.Entities.Identity.ApplicationUser? user = await _userService.FindUniqueAsync(u => u.Id == request.Id, cancellationToken);

        if (user is null)
        {
            throw new NotFoundException(nameof(user), request.Id);
        }

        await _userService.UnlockAsync(user);

        return _mapper.Map<UserDto>(user);
    }
}

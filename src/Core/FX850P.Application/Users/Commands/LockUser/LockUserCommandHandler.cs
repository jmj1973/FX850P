using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FX850P.Application.Exceptions;
using FX850P.Application.Mediator.Contracts;
using FX850P.Application.Users.Dtos;
using FX850P.Domain.Presistence.Interfaces;

namespace FX850P.Application.Users.Commands.LockUser;

public class LockUserCommandHandler : IApplicationRequestHandler<LockUserCommand, UserDto>
{
    private readonly IUserService _userService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public LockUserCommandHandler(IUserService userService, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _userService = userService;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<UserDto> Handle(LockUserCommand request, CancellationToken cancellationToken)
    {
        // Check if exist
        Domain.Entities.Identity.ApplicationUser? user = await _userService.FindUniqueAsync(u => u.Id == request.Id, cancellationToken);

        if (user is null)
        {
            throw new NotFoundException(nameof(user), request.Id);
        }

        await _userService.LockAsync(user);

        return _mapper.Map<UserDto>(user);
    }
}

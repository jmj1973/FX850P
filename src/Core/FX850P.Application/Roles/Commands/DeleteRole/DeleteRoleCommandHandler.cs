using AutoMapper;
using FX850P.Application.Common.Dtos;
using FX850P.Application.Exceptions;
using FX850P.Application.Mediator.Contracts;
using FX850P.Domain.Presistence.Interfaces;


namespace FX850P.Application.Roles.Commands.DeleteRole;

public class DeleteRoleCommandHandler : IApplicationRequestHandler<DeleteRoleCommand, KeyValuePairDto<string>>
{
    private readonly IRoleService _roleService;
    private readonly IMapper _mapper;

    public DeleteRoleCommandHandler(IRoleService roleService, IMapper mapper)
    {
        _roleService = roleService;
        _mapper = mapper;
    }

    public async Task<KeyValuePairDto<string>> Handle(DeleteRoleCommand request, CancellationToken cancellationToken = default)
    {
        // Check if exist
        Domain.Entities.Identity.ApplicationRole? role = await _roleService.FindUniqueAsync(r => r.Id == request.Id, cancellationToken);

        if (role is null)
        {
            throw new NotFoundException(nameof(role), request.Id);
        }

        await _roleService.DeleteAsync(role);

        return _mapper.Map<KeyValuePairDto<string>>(role);
    }
}

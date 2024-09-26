using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FX850P.Application.Common.Dtos;
using FX850P.Application.Exceptions;
using FX850P.Domain.Presistence.Interfaces;
using MediatR;


namespace FX850P.Application.Roles.Commands.DeleteRole;

public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommand, KeyValuePairDto<string>>
{
    private readonly IRoleService _roleService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DeleteRoleCommandHandler(IRoleService roleService, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _roleService = roleService;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<KeyValuePairDto<string>> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
    {
        // Check if exist
        var role = await _roleService.FindUniqueAsync(r => r.Id == request.Id, cancellationToken);

        if (role is null)
        {
            throw new NotFoundException(nameof(role), request.Id);
        }

        await _roleService.DeleteAsync(role);

        return _mapper.Map<KeyValuePairDto<string>>(role);
    }
}

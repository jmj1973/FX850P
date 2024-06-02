using AutoMapper;
using FX850P.Application.Common.Dtos;
using FX850P.Application.Exceptions;
using FX850P.Domain.Entities.Identity;
using FX850P.Domain.Presistence.Interfaces;
using MediatR;
using FX850P.Domain.Entities;
using System.Threading.Tasks;
using System.Threading;

namespace FX850P.Application.Roles.Commands.UpdateRole
{
    public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand, KeyValuePairDto<string>>
    {
        private readonly IRoleService _roleService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateRoleCommandHandler(IRoleService roleService, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _roleService = roleService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<KeyValuePairDto<string>> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            // Validation
            var validator = new UpdateRoleCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult.Errors);

            // Check if exist
            var role = await _roleService.FindUniqueAsync(r => r.Id == request.RoleId, cancellationToken);

            if (role is null)
            {
                throw new NotFoundException(nameof(role), request.RoleId);
            }

            _mapper.Map(request, role);

            await _roleService.UpdateAsync(role);

            return _mapper.Map<KeyValuePairDto<string>>(role);
        }
    }
}

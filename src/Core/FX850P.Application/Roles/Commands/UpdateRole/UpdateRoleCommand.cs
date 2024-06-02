using FX850P.Application.Common.Dtos;
using MediatR;
using FX850P.Application.Common.Commands;


namespace FX850P.Application.Roles.Commands.UpdateRole
{
    public class UpdateRoleCommand : BaseAuditCommand, IRequest<KeyValuePairDto<string>>
    {
        public string RoleId { get; set; } = default!;
        public string Name { get; set; } = default!;
    }
}

using FX850P.Application.Common.Commands;
using FX850P.Application.Common.Dtos;
using FX850P.Application.Mediator.Contracts;

namespace FX850P.Application.Roles.Commands.UpdateRole;

public class UpdateRoleCommand : BaseAuditCommand, IApplicationRequest<KeyValuePairDto<string>>
{
    public string RoleId { get; set; } = default!;
    public string Name { get; set; } = default!;
}

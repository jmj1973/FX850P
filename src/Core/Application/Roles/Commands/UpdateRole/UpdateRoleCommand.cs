using Application.Common.Commands;
using Application.Common.Dtos;
using Application.Mediator.Contracts;

namespace Application.Roles.Commands.UpdateRole;

public class UpdateRoleCommand : BaseAuditCommand, IApplicationRequest<KeyValuePairDto<string>>
{
    public string RoleId { get; set; } = default!;
    public string Name { get; set; } = default!;
}

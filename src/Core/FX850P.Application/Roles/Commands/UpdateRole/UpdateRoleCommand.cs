using FX850P.Application.Common.Commands;
using FX850P.Application.Common.Dtos;
using MediatR;


namespace FX850P.Application.Roles.Commands.UpdateRole;

public class UpdateRoleCommand : BaseAuditCommand, IRequest<KeyValuePairDto<string>>
{
    public string RoleId { get; set; } = default!;
    public string Name { get; set; } = default!;
}

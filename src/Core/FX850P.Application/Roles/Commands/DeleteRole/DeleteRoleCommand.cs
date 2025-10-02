using FX850P.Application.Common.Commands;
using FX850P.Application.Common.Dtos;
using FX850P.Application.Mediator.Contracts;

namespace FX850P.Application.Roles.Commands.DeleteRole;

public class DeleteRoleCommand : BaseAuditCommand, IApplicationRequest<KeyValuePairDto<string>>
{
    public string Id { get; set; } = default!;
}

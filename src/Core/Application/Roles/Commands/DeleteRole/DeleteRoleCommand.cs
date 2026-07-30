using Application.Common.Commands;
using Application.Common.Dtos;
using Application.Mediator.Contracts;

namespace Application.Roles.Commands.DeleteRole;

public class DeleteRoleCommand : BaseAuditCommand, IApplicationRequest<KeyValuePairDto<string>>
{
    public string Id { get; set; } = default!;
}

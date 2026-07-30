using Application.Common.Commands;
using Application.Common.Dtos;
using Application.Mediator.Contracts;

namespace Application.Roles.Commands.CreateRole;

public class CreateRoleCommand : BaseAuditCommand, IApplicationRequest<KeyValuePairDto<string>>
{
    public string Name { get; set; } = default!;
}

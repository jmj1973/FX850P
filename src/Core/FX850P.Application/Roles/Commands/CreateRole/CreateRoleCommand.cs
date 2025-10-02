using FX850P.Application.Common.Commands;
using FX850P.Application.Common.Dtos;
using FX850P.Application.Mediator.Contracts;

namespace FX850P.Application.Roles.Commands.CreateRole;

public class CreateRoleCommand : BaseAuditCommand, IApplicationRequest<KeyValuePairDto<string>>
{
    public string Name { get; set; } = default!;
}

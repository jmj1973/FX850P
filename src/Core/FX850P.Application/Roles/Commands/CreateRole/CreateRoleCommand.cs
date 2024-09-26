using FX850P.Application.Common.Commands;
using FX850P.Application.Common.Dtos;
using MediatR;


namespace FX850P.Application.Roles.Commands.CreateRole;

public class CreateRoleCommand : BaseAuditCommand, IRequest<KeyValuePairDto<string>>
{
    public string Name { get; set; } = default!;
}

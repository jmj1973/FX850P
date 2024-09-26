using FX850P.Application.Common.Commands;
using FX850P.Application.Common.Dtos;
using MediatR;


namespace FX850P.Application.Roles.Commands.DeleteRole;

public class DeleteRoleCommand : BaseAuditCommand, IRequest<KeyValuePairDto<string>>
{
    public string Id { get; set; } = default!;
}

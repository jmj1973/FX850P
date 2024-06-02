using FX850P.Application.Common.Dtos;
using MediatR;
using FX850P.Application.Common.Commands;


namespace FX850P.Application.Roles.Commands.CreateRole
{
    public class CreateRoleCommand : BaseAuditCommand, IRequest<KeyValuePairDto<string>>
    {
        public string Name { get; set; } = default!;
    }
}

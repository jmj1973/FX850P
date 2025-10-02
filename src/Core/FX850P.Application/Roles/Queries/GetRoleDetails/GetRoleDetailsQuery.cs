using FX850P.Application.Common.Dtos;
using FX850P.Application.Mediator.Contracts;

namespace FX850P.Application.Roles.Queries.GetRoleDetails;

public class GetRoleDetailsQuery : IApplicationRequest<KeyValuePairDto<string>>
{
    public string Id { get; set; } = default!;
}

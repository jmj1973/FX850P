using Application.Common.Dtos;
using Application.Mediator.Contracts;

namespace Application.Roles.Queries.GetRoleDetails;

public class GetRoleDetailsQuery : IApplicationRequest<KeyValuePairDto<string>>
{
    public string Id { get; set; } = default!;
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FX850P.Application.Common.Dtos;
using MediatR;

namespace FX850P.Application.Roles.Queries.GetRoleDetails;

public class GetRoleDetailsQuery : IRequest<KeyValuePairDto<string>>
{
    public string Id { get; set; } = default!;
}

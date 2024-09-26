using System;
using FX850P.Domain.Entities.Identity;

namespace FX850P.Domain.Common;

public class BaseAuditDomainEnity<TType> : BaseDomainEntity<TType>
{
    public DateTime DateCreated { get; set; } = default!;
    public string? CreatedById { get; set; } = default!;
    public ApplicationUser? CreatedBy { get; set; } = default!;
    public DateTime DateModified { get; set; } = default!;
    public string? ModifiedById { get; set; } = default!;
    public ApplicationUser? ModifiedBy { get; set; } = default!;
}

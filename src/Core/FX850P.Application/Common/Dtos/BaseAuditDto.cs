using System;

namespace FX850P.Application.Common.Dtos;

public class BaseAuditDto<TType> : BaseDto<TType>
{
    public DateTime DateCreated { get; set; } = default!;
    public string? CreatedById { get; set; } = default!;
    public DateTime DateModified { get; set; } = default!;
    public string? ModifiedById { get; set; } = default!;

}

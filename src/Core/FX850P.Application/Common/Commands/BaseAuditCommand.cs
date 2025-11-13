namespace FX850P.Application.Common.Commands;

public class BaseAuditCommand
{
    public DateTime DateCreated { get; set; }
    public string? CreatedById { get; set; } = default!;
    public DateTime DateModified { get; set; }
    public string? ModifiedById { get; set; } = default!;

}

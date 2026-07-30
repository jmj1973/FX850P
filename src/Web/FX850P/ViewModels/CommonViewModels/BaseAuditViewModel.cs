using FX850P.ViewModels.UserViewModels;

namespace FX850P.ViewModels.CommonViewModels;

public class BaseAuditViewModel<TType> : BaseViewModel<TType>
{
    public DateTime DateCreated { get; set; }
    public string? CreatedById { get; set; }
    public UserViewModel? CreatedBy { get; set; }
    public DateTime DateModified { get; set; }
    public string? ModifiedById { get; set; }
    public UserViewModel? ModifiedBy { get; set; }

}

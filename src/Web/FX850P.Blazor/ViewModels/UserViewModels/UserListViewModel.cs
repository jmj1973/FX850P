using System.ComponentModel.DataAnnotations;

namespace FX850P.Blazor.ViewModels.UserViewModels
{
    public class UserListViewModel
    {
        public string Id { get; set; } = default!;  
        public string Email { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public bool LockoutEnabled { get; set; }
    }
}

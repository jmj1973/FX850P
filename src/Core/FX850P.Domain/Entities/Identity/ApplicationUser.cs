using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace FX850P.Domain.Entities.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;

        [NotMapped]
        public string FullName
        {
            get
            {
                var space = string.IsNullOrWhiteSpace(FirstName) || string.IsNullOrWhiteSpace(LastName) ? "" : " ";
                return $"{FirstName}{space}{LastName}";
            }
        }

    }
}

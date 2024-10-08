﻿using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace FX850P.Domain.Entities.Identity;

public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;

    [NotMapped]
    public string FullName
    {
        get
        {
            string space = string.IsNullOrWhiteSpace(FirstName) || string.IsNullOrWhiteSpace(LastName) ? "" : " ";
            return $"{FirstName}{space}{LastName}";
        }
    }

}

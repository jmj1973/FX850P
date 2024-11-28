using System;
using System.ComponentModel.DataAnnotations;

namespace FX850P.Blazor.ViewModels.InformationViewModels;

public class InformationViewModel
{
    public Version Version { get; set; } = default!;

    [Display(Name = "Release Date")]
    public DateTime ReleaseDate { get; set; }

    public string Description { get; set; } = default!;
}

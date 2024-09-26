
namespace FX850P.Application.Identity.Models;

public class AuthRequest
{
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
}

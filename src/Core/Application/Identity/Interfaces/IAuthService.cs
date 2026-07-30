using Application.Identity.Models;

namespace Application.Identity.Interfaces;

public interface IAuthService
{
    Task<AuthResponse> Login(AuthRequest request);
}

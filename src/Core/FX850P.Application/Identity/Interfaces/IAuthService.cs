using System.Threading.Tasks;
using FX850P.Application.Identity.Models;

namespace FX850P.Application.Identity.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponse> Login(AuthRequest request);
    }
}

using Tech_sell_user.Application.DTOs.Request;
using Tech_sell_user.Application.DTOs.Responses;

namespace Tech_sell_user.Application.Interfaces
{
    public interface IAuthService
    {
        AuthResponse LoginAsync(AuthRequest request);
    }
}
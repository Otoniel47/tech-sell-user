using Microsoft.AspNetCore.Mvc;
using Tech_sell_user.Application.DTOs.Request;
using Tech_sell_user.Application.Interfaces;

namespace Tech_sell_user.Api.Controllers
{
    [Route("api/[controller]"), ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public IActionResult LoginAsync(AuthRequest request)
        {
            try
            {
                return Ok(_authService.LoginAsync(request));
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Success = false,
                    Message = ex.Message
                });
            }
        }
    }
}
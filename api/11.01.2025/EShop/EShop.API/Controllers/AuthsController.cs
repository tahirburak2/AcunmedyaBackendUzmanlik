using EShop.Service.Abstract;
using EShop.Shared.Dtos.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EShop.API.Controllers
{
    [Route("api/auths")]
    [ApiController]
    public class AuthsController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthsController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto){
           var result= await _authService.LoginAsync(loginDto);
            return StatusCode(result.StatusCode,result);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto registerDto){
            var result= await _authService.RegisterAsync(registerDto);
            return StatusCode(result.StatusCode,result);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using PatientManagementSystem.DTOs;
using PatientManagementSystem.Services;

namespace PatientManagementSystem.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var result = await _authService.Register(dto);

            return StatusCode(201, result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var token = await _authService.Login(dto);

            return Ok(new
            {
                token
            });
        }
    }
}
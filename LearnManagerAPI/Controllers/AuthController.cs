using Microsoft.AspNetCore.Mvc;
using LearnManagerAPI.Services.Interfaces;
using LearnManagerAPI.DTOs;
using LearnManagerAPI.Models;

namespace LearnManagerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(RegisterDto dto)
        {
            var user = await _authService.RegisterAsync(dto);
            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(LoginDto dto)
        {
            var token = await _authService.LoginAsync(dto);
            return Ok(token);
        }
    }
}
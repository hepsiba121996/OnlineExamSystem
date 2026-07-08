using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineExamSystem.DTOs;
using OnlineExamSystem.Services.Interfaces;

namespace OnlineExamSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("registr")]
        public async Task<IActionResult>redister(RegisterDto registerDto)
        {
            var resut=await _authService.Register(registerDto);
            return Ok(resut);
        }
        [HttpPost("login")]
        public async Task<IActionResult> login(LoginDto loginDto)
        {
            var result=await _authService.Login(loginDto);
            if(result == null)
            {
                return Unauthorized("invalid Email and passwoed");
            }
            return Ok(result);
        }
    }
}

using OnlineExamSystem.DTOs;

namespace OnlineExamSystem.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string>Register(RegisterDto registerDto);
        Task<LoginResponseDto>Login(LoginDto loginDto);
    }
}

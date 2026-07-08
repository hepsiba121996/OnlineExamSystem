using Microsoft.EntityFrameworkCore;
using OnlineExamSystem.Data;
using OnlineExamSystem.DTOs;
using OnlineExamSystem.Helpers;
using OnlineExamSystem.Models;
using OnlineExamSystem.Services.Interfaces;

namespace OnlineExamSystem.Services.Implementations
{
    public class AuthService:IAuthService
    {
        private readonly MyDbContext _mydbcontext;
        private readonly JwtHelper _jwthelper;
        public AuthService(MyDbContext mydbcontext,JwtHelper jwtHelper)
        {
            _mydbcontext = mydbcontext;
            _jwthelper = jwtHelper;
        }
        public async Task<string> Register(RegisterDto registerDto)
        {
            var exits = await _mydbcontext.Students.AnyAsync(x => x.Email == registerDto.Email);
            if (exits)
            {
                return "Email already exists";

            }
            var student = new Student
            {
                StudentName = registerDto.StudentName,
                Email = registerDto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(
                                          registerDto.PasswordHash),
                PhoneNumber = registerDto.PhoneNumber,
                IsActive = true
            };
            _mydbcontext.Students.Add(student);
            await _mydbcontext.SaveChangesAsync();
            return "Registration Successful";
        }
       
        public async Task<LoginResponseDto> Login(LoginDto loginDto)
        {
            var student=await _mydbcontext.Students.FirstOrDefaultAsync(x=>x.Email == loginDto.Email);
            if (student == null)
            {
                throw new Exception("Email not found");
            }
            bool password = BCrypt.Net.BCrypt.Verify(loginDto.Password,
                               student.PasswordHash);
            if (!password)
            {
                throw new Exception("invalid password");
            }
            var token=_jwthelper.GenerateToken(student.StudentId,student.Email,"Student");
            return new LoginResponseDto
            {
                Token = token,
                Role = "Student"
            };
        }
    }
    
}

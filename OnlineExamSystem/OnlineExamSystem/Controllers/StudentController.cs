using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineExamSystem.Models;
using OnlineExamSystem.Repositories.Interfaces;

namespace OnlineExamSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        [HttpGet("AllStudents")]
        public async Task<IActionResult>GetallStudents()
        {
            var stu=await _studentRepository.GetAllAsync();
            return Ok(stu);
        }
        [HttpGet("StudentId")]
        public async Task<IActionResult>GetSutdentId(int id)
        {
            var stuid=await _studentRepository.GetByIdAsync(id);
            return Ok(stuid);
        }
        [HttpPost("AddStudent")]
        public async Task<IActionResult>AddStudent(Student student)
        {
            var addstu=await _studentRepository.AddAsync(student);
            return Ok(addstu);
        }
        [HttpPut("EditStudent")]
        public async Task<IActionResult>ModifySudent(int id,Student student)
        {
            var updatestu=await _studentRepository.UpdateAsync(id,student);
            return Ok(updatestu);
        }
        [HttpDelete("DeleteStudent")]
        public async Task<IActionResult>RemoveStudent(int id)
        {
            var deletestu=await _studentRepository.RemoveAsync(id);
            return Ok(deletestu);
        }

    }
}

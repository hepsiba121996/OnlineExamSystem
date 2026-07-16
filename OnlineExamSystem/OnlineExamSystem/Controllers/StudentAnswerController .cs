using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineExamSystem.Models;
using OnlineExamSystem.Services.Interfaces;

namespace OnlineExamSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAnswerController : ControllerBase
    {
        private readonly IStudentAnswerService _studentAnswerService;
        public StudentAnswerController(IStudentAnswerService studentAnswerService)
        {
            _studentAnswerService = studentAnswerService;
        }
        [HttpPost]
        public async Task<IActionResult> SaveAnswer(StudentAnswer answer)
        {
            var result = await _studentAnswerService.SaveAnswer(answer);

            return Ok(result);
        }
    }
}

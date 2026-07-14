using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineExamSystem.Services.Interfaces;

namespace OnlineExamSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentExamController : ControllerBase
    {
        private readonly IStudentExamService _studentExamService;
        public StudentExamController(IStudentExamService studentExamService)
        {
            _studentExamService = studentExamService;
        }
        [HttpPost("assign")]
        public async Task<IActionResult> AssignExam(int studentId, int examId)
        {
            var result=await _studentExamService.AssignExam(studentId, examId);
            return Ok(result);
        }

        [HttpGet("student/{studentId}")]
        public async Task<IActionResult> GetStudentExams(int studentId)
        {
            var result = await _studentExamService.GetStudentExams(studentId);
            return Ok(result);
            
        }

        [HttpPut("start/{studentExamId}")]
       public async Task<IActionResult> StartExam(int studentExamId)
        {
            var result =await _studentExamService.StartExam(studentExamId);


            if (result == null)
            {
                return NotFound();
            }


            return Ok(result);

        }
        [HttpPut("submit/{studentExamId}")]

        public async Task<IActionResult> SubmitExam(int studentExamId)
        {

            var result =
           await _studentExamService.SubmitExam(studentExamId);


            return Ok(result);

        }
        [HttpPost("assign-all/{examId}")]
        public async Task<IActionResult> AssignExamToAllStudents(int examId)
        {
            var result = await _studentExamService.AssignExamToAllStudents(examId);

            return Ok(result);
        }

    }
}

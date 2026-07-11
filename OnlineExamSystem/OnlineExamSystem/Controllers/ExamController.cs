using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineExamSystem.DTOs;
using OnlineExamSystem.Models;
using OnlineExamSystem.Repositories.Interfaces;
using OnlineExamSystem.Services.Interfaces;

namespace OnlineExamSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private readonly IExamRepository _examRepository;
        private readonly IExamService _examService;
        public ExamController(IExamRepository examRepository,IExamService examService)
        {
            _examRepository = examRepository;
            _examService = examService;
        }
        [HttpPost("CreateExam")]
        public async Task<IActionResult> CreateExam(CreateExamDto dto)
        {
            var result=await _examService.CreateExam(dto);
            return Ok(result);
        }
        [HttpGet("GetExams")]
        public async Task<IActionResult>GetExams()
        {
            var result = await _examService.GetExams();
            return Ok(result);
        }
        [HttpGet("ExamId")]
        public async Task<IActionResult>GetExam(int id)
        {
            var result=await _examService.GetExam(id);
            return Ok(result);
        }
        [HttpGet("AllExams")]
        public async Task<IActionResult>GetExam()
        {
            var result = await _examRepository.GellAllAsync();
            return Ok(result);
        }
        [HttpGet("GetExamId")]
        public async Task<IActionResult>ExamId(int id)
        {
            var exId=await _examRepository.GellByIdAsync(id);
            return Ok(exId);
        }
        [HttpPost("AddExam")]
        public async Task<IActionResult>AddExam(Exam exam)
        {
            var exm=await _examRepository.addAsync(exam);
            return Ok(exm);
        }
        [HttpPut("EditExam")]
        public async Task<IActionResult>ModifyExam(int id,Exam exam)
        {
            var updateExam=await _examRepository.updateAsync(id,exam);
            return Ok(updateExam);
        }
        [HttpDelete("DeleteExam")]
        public async Task<IActionResult>delteexam(int id)
        {
            var deleteEx=await _examRepository.deleteAsync(id);
            return Ok(deleteEx);
        }
    }
}

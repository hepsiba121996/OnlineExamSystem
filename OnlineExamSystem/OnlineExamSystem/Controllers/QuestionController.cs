using Microsoft.AspNetCore.Authorization;
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
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IQuestionService _questionService;

        public QuestionController(IQuestionRepository questionRepository,IQuestionService questionService)
        {
            _questionRepository = questionRepository;
            _questionService = questionService;
        }
        [HttpPost("AddQuestion")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult>AddQuestion(CreateQuestionDto dto)
        {
            var result = await _questionService.AddQuestion(dto);
            return Ok(result);
        }
        //[HttpGet("QuesionId")]
        //public async Task<IActionResult>GetQuestionId(int id)
        //{
        //    var result=await _questionService.GetQuestions(id);
        //    return Ok(result);
        //}

        [HttpGet("GetAllQuestions")]
        public async Task<IActionResult>GetAllQue()
        {
            var question = await _questionRepository.GetAllQuestions();
            return Ok(question);
        }
        [HttpGet("GetQuestionid")]
        public async Task<IActionResult>GetQueId(int id)
        {
            var queId=await _questionRepository.GetQuestionById(id);
            return Ok(queId);
        }
        
        [HttpPut("EditQuestion")]
        public async Task<IActionResult>ModifyQue(int id,Question question)
        {
            var updateQue=await _questionRepository.update(id,question);
            return Ok(updateQue);
        }
        [HttpDelete("RemoveQuestion")]
        public async Task<IActionResult>removeque(int id)
        {
            var deleteque=await _questionRepository.delete(id);
            return Ok(deleteque);
        }
        [HttpGet("exam/{examId}")]
        public async Task<IActionResult> GetQuestionsByExamId(int examId)
        {
            var result = await _questionService.GetQuestionsByExamId(examId);

            return Ok(result);
        }
    }
}

using OnlineExamSystem.Controllers;
using OnlineExamSystem.DTOs;
using OnlineExamSystem.Models;
using OnlineExamSystem.Repositories.Interfaces;
using OnlineExamSystem.Services.Interfaces;

namespace OnlineExamSystem.Services.Implementations
{
    public class QuestionService:IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;
        public QuestionService(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }
        public async Task<string> AddQuestion(CreateQuestionDto dto)
        {
            var question = new Question
            {
             QuestionText= dto.QuestionText,
             OptionA= dto.OptionA,
             OptionB= dto.OptionB,
             OptionC= dto.OptionC,
             OptionD= dto.OptionD,
             CorrectAnswer= dto.CorrectAnswer,
             ExamId= dto.ExamId
            };
            await _questionRepository.add(question);
            return "Question Added";

        }
        public async Task<Question> GetQuestions(int id)
        {
           return await _questionRepository.GetQuestionById(id);
            
        }
    }
}

using OnlineExamSystem.Data;
using OnlineExamSystem.DTOs;
using OnlineExamSystem.Models;
namespace OnlineExamSystem.Services.Interfaces
{
    public interface IQuestionService
    {
        Task<string> AddQuestion(CreateQuestionDto question);
        Task<Question> GetQuestions(int id);
        Task<List<QuestionResponseDto>> GetQuestionsByExamId(int examId);







    }
}

using OnlineExamSystem.Models;
namespace OnlineExamSystem.Repositories.Interfaces
{
    public interface IQuestionRepository
    {
        Task<List<Question>> GetAllQuestions();
        Task<Question> GetQuestionById(int id);
        Task<Question> add(Question question);
        Task<Question> update(int id,Question question);
        Task<Question> delete(int id);
        Task<List<Question>> GetQuestionsByExamId(int examId);

    }
}

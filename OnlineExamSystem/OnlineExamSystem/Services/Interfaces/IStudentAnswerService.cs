using OnlineExamSystem.Models;
namespace OnlineExamSystem.Services.Interfaces
{
    public interface IStudentAnswerService
    {
        Task<string> SaveAnswer(StudentAnswer answer);

    }
}


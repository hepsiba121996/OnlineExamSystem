using OnlineExamSystem.Models;
using OnlineExamSystem.Data;
using OnlineExamSystem.DTOs;
namespace OnlineExamSystem.Services.Interfaces
{
    public interface IExamService
    {
        Task<string>CreateExam(CreateExamDto dto);
        Task<List<Exam>> GetExams();
        Task<Exam> GetExam(int id);
    }
}

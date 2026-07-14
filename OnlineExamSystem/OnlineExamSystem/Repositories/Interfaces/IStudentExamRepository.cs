using OnlineExamSystem.Models;
namespace OnlineExamSystem.Repositories.Interfaces
{
    public interface IStudentExamRepository
    {
        Task AddAsync(StudentExam studentexam);
        Task<List<StudentExam>> GetStudentExams(int studentId);
        Task<StudentExam?> GetById(int id);
        Task Update(StudentExam studentExam);
        Task<StudentExam?> GetByStudentAndExam(int studentId, int examId);
        Task SaveAsync();
    }
}

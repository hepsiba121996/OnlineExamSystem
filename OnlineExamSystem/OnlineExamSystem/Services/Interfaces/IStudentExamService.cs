using OnlineExamSystem.DTOs;
using OnlineExamSystem.Models;

namespace OnlineExamSystem.Services.Interfaces
{
    public interface IStudentExamService
    {
         Task<string> AssignExam(int studentId,int examId);

        Task<List<StudentExam>> GetStudentExams(int studentId);
        Task<StudentExamResponseDto?> StartExam(int studentExamId);

        Task<string> AssignExamToAllStudents(int examId);
        Task<string> SubmitExam(int studentExamId);



    }
}

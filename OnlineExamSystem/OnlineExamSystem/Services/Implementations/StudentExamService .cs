using OnlineExamSystem.Models;
using OnlineExamSystem.Data;
using OnlineExamSystem.Repositories.Interfaces;
using OnlineExamSystem.Services.Interfaces;
using OnlineExamSystem.DTOs;
using Microsoft.AspNetCore.Http.HttpResults;
using DocumentFormat.OpenXml.InkML;
using Microsoft.EntityFrameworkCore;
namespace OnlineExamSystem.Services.Implementations
{
    public class StudentExamService : IStudentExamService
    {
        private readonly IStudentExamRepository _studentExamRepository;
        private readonly MyDbContext _dbContext;

        public StudentExamService(IStudentExamRepository studentExamRepository, MyDbContext myDbContext)
        {
            _studentExamRepository = studentExamRepository;
            _dbContext = myDbContext;
        }
        public async Task<string> AssignExam(int studentId, int examId)
        {
            var existing = await _studentExamRepository.GetByStudentAndExam(studentId, examId);
            if (existing != null)
            {
                return "Already assigned";

            }
            var studentExam = new StudentExam
            {
                StudentId = studentId,
                ExamId = examId,
                Status = "Assigned"
            };

            await _studentExamRepository.AddAsync(studentExam);
            await _studentExamRepository.SaveAsync();
            return "Assigned successfully";

        }
        public async Task<List<StudentExam>> GetStudentExams(int studentId)
        {
            return await _studentExamRepository.GetStudentExams(studentId);

        }
        public async Task<StudentExamResponseDto?> StartExam(int studentExamId)
        {

            var result =
                await _studentExamRepository.GetById(studentExamId);


            if (result == null)
            {
                return null;
            }


            result.StartedTime = DateTime.Now;

            result.Status = "Started";


            await _studentExamRepository.Update(result);



            var response = new StudentExamResponseDto
            {
                StudentExamId = result.StudentExamId,

                StudentId = result.StudentId,

                ExamId = result.ExamId,

                Status = result.Status,

                StartedTime = result.StartedTime,

                SubmittedTime = result.SubmittedTime,

                title = result.Exam.title
            };
            await _studentExamRepository.SaveAsync();

            return response;

        }
        public async Task<string> SubmitExam(int studentExamId)
        {
            var studentExam = await _studentExamRepository.GetById(studentExamId);
            if (studentExam == null)
            {
                return "Exam not found";

            }
            studentExam.SubmittedTime = DateTime.Now;
            studentExam.Status = "completed";
            await _studentExamRepository.Update(studentExam);
            return "Exam Submitted Successfully";


        }
        public async Task<string> AssignExamToAllStudents(int examId)
        {
            //get all students
            var students = await _dbContext.Students.ToListAsync();
            foreach (var student in students)
            {
                var result = await _studentExamRepository.GetByStudentAndExam(student.StudentId, examId);
                if (result == null)
                {
                    var studentexam = new StudentExam
                    {
                        StudentId = student.StudentId,
                        ExamId = examId,
                        Status = "Assigned"
                    };
                    await _studentExamRepository.AddAsync(studentexam);
                }
            }
            await _studentExamRepository.SaveAsync();

            return "Exam assigned to all students successfully";



        }
    }
}

using OnlineExamSystem.Data;
using OnlineExamSystem.DTOs;
using OnlineExamSystem.Models;
using OnlineExamSystem.Repositories.Interfaces;
using OnlineExamSystem.Services.Interfaces;

namespace OnlineExamSystem.Services.Implementations
{
    public class ExamService : IExamService
    {
        private readonly IExamRepository _repository;
        public ExamService(IExamRepository repository)
        {
            _repository = repository;
        }
        public async Task<string> CreateExam(CreateExamDto dto)
        {
            var exm = new Exam
            {
                title = dto.Title,
                duration = dto.Duration,
                TotalMarks = dto.TotalMarks,
                SubjectId = dto.SubjectId,
            };
            await _repository.addAsync(exm);
            return "Exam Created Successfully";


        }
        public async Task<List<Exam>> GetExams()
        {
          return  await _repository.GellAllAsync();
        }
        public async Task<Exam> GetExam(int id)
        {
            return await _repository.GellByIdAsync(id);
        }
    }
}

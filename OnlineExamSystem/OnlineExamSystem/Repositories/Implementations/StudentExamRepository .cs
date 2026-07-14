using DocumentFormat.OpenXml.InkML;
using Microsoft.EntityFrameworkCore;
using OnlineExamSystem.Data;
using OnlineExamSystem.Models;
using OnlineExamSystem.Repositories.Interfaces;


namespace OnlineExamSystem.Repositories.Implementations
{
    public class StudentExamRepository: IStudentExamRepository
    {
        private readonly MyDbContext _dbContext;
        public StudentExamRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddAsync(StudentExam studentExam)
        {
           await _dbContext.StudentExam.AddAsync(studentExam);
            await _dbContext.SaveChangesAsync();
            
        }
        public async Task<List<StudentExam>> GetStudentExams(int studentId)
        {
            return await _dbContext.StudentExam.
                 Include(x => x.Exam).Where(x => x.StudentId == studentId).ToListAsync();


        }
        public async Task<StudentExam?> GetById(int id)
        {
            return await _dbContext.StudentExam
                           .Include(x=>x.Exam)
                           .Include(s=>s.Student)
                           .FirstOrDefaultAsync(x=>x.StudentExamId == id);

        }
        public async Task Update(StudentExam studentExam)
        {

            _dbContext.StudentExam.Update(studentExam);


            await _dbContext.SaveChangesAsync();

        }
        public async Task<StudentExam?> GetByStudentAndExam(int studentId,int examId)
        {
            return await _dbContext.StudentExam
                .FirstOrDefaultAsync(x =>
                    x.StudentId == studentId &&
                    x.ExamId == examId);
        }
        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();


        }
    }
}

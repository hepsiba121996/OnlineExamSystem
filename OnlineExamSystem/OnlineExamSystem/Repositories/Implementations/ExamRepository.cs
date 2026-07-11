
using Microsoft.EntityFrameworkCore;
using OnlineExamSystem.Data;
using OnlineExamSystem.Models;
using OnlineExamSystem.Repositories.Interfaces;

namespace OnlineExamSystem.Repositories.Implementations
{
    public class ExamRepository:IExamRepository
    {
        private readonly MyDbContext _dbContext;
        public ExamRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Exam>> GellAllAsync()
        {
            return await _dbContext.exam.ToListAsync();
        }
        public async Task<Exam> GellByIdAsync(int id)
        {
            var result=await _dbContext.exam.FirstOrDefaultAsync(x=>x.ExamId==id);
            if (result==null)
            {
                Console.WriteLine("ExamId Not found");
            }
            return result;
        }
        public async Task<Exam> addAsync(Exam exm)
        {
             await _dbContext.exam.AddAsync(exm);
            await _dbContext.SaveChangesAsync();
            return exm;
            
        }
        public async Task<Exam> updateAsync(int id, Exam exam)
        {
            var result = await _dbContext.exam.FirstOrDefaultAsync(x => x.ExamId == id);
            if (result == null)
            {
                Console.WriteLine("ExamId Not found");
            }
            var exm = new Exam
            {
                title = result.title,
                duration = result.duration,
                TotalMarks = result.TotalMarks,
                Subject = result.Subject,
                Questions = result.Questions,
            };
            await _dbContext.SaveChangesAsync();
            return exm;
        }
        public async Task<Exam> deleteAsync(int id)
        {
            var result= await _dbContext.exam.FirstOrDefaultAsync(x=>x.ExamId== id);
             _dbContext.exam.Remove(result);
            await _dbContext.SaveChangesAsync();
            return result;
        }
    }
}

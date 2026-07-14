using Microsoft.EntityFrameworkCore;
using OnlineExamSystem.Data;
using OnlineExamSystem.Models;
using OnlineExamSystem.Repositories.Interfaces;

namespace OnlineExamSystem.Repositories.Implementations
{
    public class QuestionRepository: IQuestionRepository
    {
        private readonly MyDbContext _dbContext;
        public QuestionRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Question>> GetAllQuestions()
        {
            return await _dbContext.question.ToListAsync();
            
        }
        public async Task<Question> GetQuestionById(int id)
        {
            var queid = await _dbContext.question.FirstOrDefaultAsync(x => x.QuestionId == id);
            return queid;

        }
        public async Task<Question>add(Question question)
        {
            _dbContext.question.Add(question);
            await _dbContext.SaveChangesAsync();
            return question;
        }
        public async Task<Question> update(int id,Question question)
        {
          var result=await _dbContext.question.FirstOrDefaultAsync(x=>x.QuestionId == id);
            if (result != null)
            {
                _dbContext.question.Remove(result);
            }
                await _dbContext.SaveChangesAsync();
                return result;
        }
        public async Task<Question> delete(int id)
        {
            var result = await _dbContext.question.FirstOrDefaultAsync(x => x.QuestionId == id);
            if (result != null)
            {
                _dbContext.question.Remove(result);
            }
            await _dbContext.SaveChangesAsync();
            return result;
        }
        public async Task<List<Question>> GetQuestionsByExamId(int examId)
        {
             return await _dbContext.question.Where(x=>x.ExamId==examId).ToListAsync();
        }


    }
}

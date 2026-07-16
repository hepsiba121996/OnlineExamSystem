using DocumentFormat.OpenXml.InkML;
using Microsoft.EntityFrameworkCore;
using OnlineExamSystem.Data;
using OnlineExamSystem.Models;
using OnlineExamSystem.Services.Interfaces;

namespace OnlineExamSystem.Services.Implementations
{
    public class StudentAnswerService: IStudentAnswerService
    {
        private readonly MyDbContext _myDbContext;
        public StudentAnswerService(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }
        public async Task<string> SaveAnswer(StudentAnswer answer)
        {
            var existing = await _myDbContext.studentAnswer
                           .FirstOrDefaultAsync(x =>
                           x.StudentExamId == answer.StudentExamId && x.QuestionId == answer.QuestionId);
            if (existing != null)
            {
                existing.SelectedOption = answer.SelectedOption;

            }
            else
            {
                var studentanswer = new StudentAnswer
                {
                    StudentExamId = answer.StudentExamId,
                    QuestionId = answer.QuestionId,
                    SelectedOption = answer.SelectedOption
                };
                await _myDbContext.studentAnswer.AddAsync(studentanswer);
            }
            await _myDbContext.SaveChangesAsync();
            return "Answer saved successfully";


        }
    }
}

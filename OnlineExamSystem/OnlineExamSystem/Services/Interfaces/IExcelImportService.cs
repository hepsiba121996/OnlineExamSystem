using Microsoft.AspNetCore.Http;
namespace OnlineExamSystem.Services.Interfaces
{
    public interface IExcelImportService
    {
        Task<string> ImportQuestions(IFormFile file, int examId);
    }
}

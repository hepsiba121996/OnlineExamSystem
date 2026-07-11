using OnlineExamSystem.Models;
namespace OnlineExamSystem.Repositories.Interfaces
{
    public interface IExamRepository
    {
        Task<List<Exam>> GellAllAsync();
        Task<Exam> GellByIdAsync(int id);
        Task<Exam> addAsync(Exam exam);
        Task<Exam> updateAsync(int id,Exam exam);
        Task<Exam> deleteAsync(int id);
    }
}

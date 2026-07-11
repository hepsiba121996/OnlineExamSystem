using OnlineExamSystem.Models;
namespace OnlineExamSystem.Repositories.Interfaces
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllAsync();
        Task<Student> GetByIdAsync(int id);
        Task<Student> AddAsync(Student student);
        Task<Student> UpdateAsync(int id,Student student);
        Task<Student> RemoveAsync(int id);
    }
}

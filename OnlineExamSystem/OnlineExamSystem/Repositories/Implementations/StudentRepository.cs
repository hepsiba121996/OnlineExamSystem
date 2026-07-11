using Microsoft.EntityFrameworkCore;
using OnlineExamSystem.Data;
using OnlineExamSystem.Models;
using OnlineExamSystem.Repositories.Interfaces;

namespace OnlineExamSystem.Repositories.Implementations
{
    public class StudentRepository:IStudentRepository
    {
        private readonly MyDbContext _mydbcontext;
        public StudentRepository(MyDbContext mydbcontext)
        {
            _mydbcontext = mydbcontext;
        }
        public async Task<List<Student>> GetAllAsync()
        {
            return await _mydbcontext.Students.ToListAsync();

        }
        public async Task<Student> GetByIdAsync(int id)
        {
            return await _mydbcontext.Students.FirstOrDefaultAsync(x=>x.StudentId==id);
          
        }
        public async Task<Student> AddAsync(Student student)
        {
            await _mydbcontext.Students.AddAsync(student);

            await _mydbcontext.SaveChangesAsync();
            return student;
        }
        public async Task<Student> UpdateAsync(int id,Student student)
        {
           var resul=await _mydbcontext.Students.FirstOrDefaultAsync(x=>x.StudentId==id);
            var stu = new Student
            {
                StudentName= resul.StudentName,
                Email= resul.Email,
                PasswordHash= resul.PasswordHash,
                PhoneNumber= resul.PhoneNumber,
                IsActive=resul.IsActive
            };
            await _mydbcontext.SaveChangesAsync();
            return stu;
        }
        public async Task<Student> RemoveAsync(int id)
        {
            var result = await _mydbcontext.Students.FindAsync(id);
            _mydbcontext.Students.Remove(result);
            await _mydbcontext.SaveChangesAsync();
            return result;
        }
    }
}

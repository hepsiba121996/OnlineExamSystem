using Microsoft.EntityFrameworkCore;
using OnlineExamSystem.Models;
using OnlineExamSystem.Models;

namespace OnlineExamSystem.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options):base(options) 
        { }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentExam> StudentExam { get; set; }
        public DbSet<Admin>admins { get; set; }
        public DbSet<Exam> exam { get; set; }
        public DbSet<Question> question { get; set; }
        public DbSet<Result> results {  get; set; }
        public DbSet<StudentAnswer> studentAnswer { get; set; }
        public DbSet<Subject> subject { get; set; }
    }
    
}

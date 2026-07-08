using System.ComponentModel.DataAnnotations;

namespace OnlineExamSystem.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        [Required]
        public string StudentName { get; set; }
        [Required]
        public string Email {  get; set; }
        [Required]
        public string PasswordHash { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsActive { get; set; }

        public ICollection<StudentExam> studentExams {  get; set; }



    }
}

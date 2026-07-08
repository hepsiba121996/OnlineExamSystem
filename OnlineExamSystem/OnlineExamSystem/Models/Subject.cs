using System.ComponentModel.DataAnnotations;

namespace OnlineExamSystem.Models
{
    public class Subject
    {
        [Key]
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public ICollection<Exam> exams {  get; set; }
    }
}

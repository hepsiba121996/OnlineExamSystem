using System.ComponentModel.DataAnnotations;

namespace OnlineExamSystem.Models
{
    public class Exam
    {
        [Key]
        public int ExamId {  get; set; }
        public string title {  get; set; }
        public string duration {  get; set; }
        public string TotalMarks {  get; set; }
        public int SubjectId {  get; set; }
        public ICollection<Question> Questions {  get; set; }
        public Subject Subject { get; set; }
    }
}

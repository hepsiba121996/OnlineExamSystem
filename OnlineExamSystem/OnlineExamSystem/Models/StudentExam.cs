using System.ComponentModel.DataAnnotations;

namespace OnlineExamSystem.Models
{
    public class StudentExam
    {
        [Key]
        public int StudentExamId { get; set; }



        public int StudentId { get; set; }


        public Student Student { get; set; }



        public int ExamId { get; set; }


        public Exam Exam { get; set; }



        public DateTime? StartedTime { get; set; }


        public DateTime? SubmittedTime { get; set; }



        public string Status { get; set; }

    }
}

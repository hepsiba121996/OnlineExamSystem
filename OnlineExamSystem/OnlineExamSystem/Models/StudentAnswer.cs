using System.ComponentModel.DataAnnotations;

namespace OnlineExamSystem.Models
{
    public class StudentAnswer
    {
        [Key]
        public int AnswerId {  get; set; }
        public int StudentExamId {  get; set; }
        public int QuestionId {  get; set; }
        public string SelectedOption {  get; set; }
    }
}

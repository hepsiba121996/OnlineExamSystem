using System.ComponentModel.DataAnnotations;

namespace OnlineExamSystem.Models
{
    public class Result
    {
        [Key]
        public int ResultId { get; set; }


        public int StudentExamId { get; set; }



        public int TotalQuestions { get; set; }


        public int CorrectAnswers { get; set; }


        public int WrongAnswers { get; set; }


        public int Marks { get; set; }

    }
}

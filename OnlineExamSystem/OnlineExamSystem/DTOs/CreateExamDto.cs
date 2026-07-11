using OnlineExamSystem.Models;
namespace OnlineExamSystem.DTOs
{
    public class CreateExamDto
    {
        public string Title { get; set; }


        public string Duration { get; set; }


        public string TotalMarks { get; set; }


        public int SubjectId { get; set; }

    }
}


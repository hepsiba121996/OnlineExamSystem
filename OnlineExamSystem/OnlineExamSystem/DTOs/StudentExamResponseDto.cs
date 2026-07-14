namespace OnlineExamSystem.DTOs
{
    public class StudentExamResponseDto
    {
        public int StudentExamId { get; set; }

        public int StudentId { get; set; }

        public int ExamId { get; set; }

        public string Status { get; set; }

        public DateTime? StartedTime { get; set; }

        public DateTime? SubmittedTime { get; set; }

        public string title { get; set; }

    }
}

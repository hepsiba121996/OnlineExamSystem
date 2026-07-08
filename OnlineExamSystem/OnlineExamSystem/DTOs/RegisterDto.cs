namespace OnlineExamSystem.DTOs
{
    public class RegisterDto
    {
        public string StudentName{get; set;}
        public string Email { get; set; }
        public string PasswordHash { get; set;}
        public string PhoneNumber { get; set;}
    }
}

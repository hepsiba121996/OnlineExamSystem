using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace OnlineExamSystem.Models
{
    public class Admin
    {
        [Key]
        public int AdminId {  get; set; }
        public string AdminName { get; set; }
        public string Email {  get; set; }
        public string PasswordHash { get; set; }
    }
}

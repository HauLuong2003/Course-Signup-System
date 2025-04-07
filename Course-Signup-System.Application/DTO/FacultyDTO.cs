using System.ComponentModel.DataAnnotations;

namespace Course_Signup_System.Application.DTO
{
    public class FacultyDTO
    {
        [Required]
        public string FacultyId { get; set; } = null!;
        [Required]
        public string FacultyName { get; set; } = null!;
    }
}

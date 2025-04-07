using System.ComponentModel.DataAnnotations;

namespace Course_Signup_System.Application.DTO
{
    public class ClassOfDTO
    {
        [Required]
        public string ClassOfId { get; set; } = null!;

        [Required]
        public string ClassOfName { get; set; } = null!;

        public DateTime StartStudy { get; set; }

        public DateTime EndStudy { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Course_Signup_System.Application.DTO
{
    public class DepartmentDTO
    {
        public int? DepartmentId { get; set; }

        [Required]
        public string DepartmentName { get; set; } = null!;
    }
}

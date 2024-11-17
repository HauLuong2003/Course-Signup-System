using System.ComponentModel.DataAnnotations;

namespace Course_Signup_System.DTO
{
    public class RoleDTO
    {
        public int? RoleId { get; set; } 
        [Required]
        public string RoleName { get; set; } = null!;
    }
}

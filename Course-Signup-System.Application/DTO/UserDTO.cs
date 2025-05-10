using System.ComponentModel.DataAnnotations;

namespace Course_Signup_System.Application.DTO
{
    public class UserDTO
    {
        
        public string? UserId { get; set; } = null!;
        [Required]
        public string FirstName { get; set; } = null!;
        [Required] 
        public string LastName { get; set; } = null!;
        [Required, EmailAddress]
        public string Email { get; set; } = null!;

        public string? Password { get; set; } = null!;

        public DateTime? CreateAt { get; set; }

        public DateTime? UpdateAt { get; set; }

        public string? Avatar {  get; set; }
        [Required]
        public int RoleId { get; set; }
    }
}

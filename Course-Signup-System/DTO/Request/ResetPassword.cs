using System.ComponentModel.DataAnnotations;

namespace Course_Signup_System.DTO.Request
{
    public class ResetPassword
    {
        public string Email { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
        [Required,Compare("Password")]
        public string ComfirmPassword { get; set; } = null!;
    }
}

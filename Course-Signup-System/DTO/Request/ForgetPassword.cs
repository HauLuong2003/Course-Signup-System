using System.ComponentModel.DataAnnotations;

namespace Course_Signup_System.DTO.Request
{
    public class ForgetPassword
    {
        [Required, EmailAddress]
        public string Email { get; set; } = null!;

    }
}

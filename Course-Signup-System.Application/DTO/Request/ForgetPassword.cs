using System.ComponentModel.DataAnnotations;

namespace Course_Signup_System.Application.DTO.Request
{
    public class ForgetPassword
    {
        [Required, EmailAddress]
        public string Email { get; set; } = null!;

    }
}

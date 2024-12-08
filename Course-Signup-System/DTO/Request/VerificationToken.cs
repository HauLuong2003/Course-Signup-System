namespace Course_Signup_System.DTO.Request
{
    public class VerificationToken
    {
        public string Email { get; set; } = null!;
        public string Token { get; set; } = null!;
    }
}

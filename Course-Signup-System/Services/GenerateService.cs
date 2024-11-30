using Course_Signup_System.Entities;

namespace Course_Signup_System.Services
{
    public interface GenerateService
    {
        Task<string> GenerateCodeAsync();
        Task<string> GenerateJwtToken(User user);
    }
}

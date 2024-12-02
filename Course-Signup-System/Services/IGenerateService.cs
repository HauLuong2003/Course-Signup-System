using Course_Signup_System.Entities;

namespace Course_Signup_System.Services
{
    public interface IGenerateService
    {
        Task<string> GenerateCodeAsync();
        Task<string> GenerateJwtToken(User user);
        Task<bool> SendEmail(string email); 
        Task<bool> VerificationToken(string email, string Token);
        Task<string> GenerateVerificationToken (string email);
    }
}

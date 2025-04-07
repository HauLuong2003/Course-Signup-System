using Course_Signup_System.Domain.Entities;

namespace Course_Signup_System.Application.Services
{
    public interface IGenerateService
    {
        Task<string> GenerateCodeAsync();
        Task<string> GenerateJwtToken(User user);
        Task<bool> SendEmail(string email); 
        Task<string> GenerateVerificationToken (string email);
    }
}

using Course_Signup_System.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Course_Signup_System.Services
{
    public interface IGenerateService
    {
        Task<string> GenerateCodeAsync();
        Task<string> GenerateJwtToken(User user);
        Task<bool> SendEmail(string email); 
        Task<string> GenerateVerificationToken (string email);
    }
}

using Course_Signup_System.DTO.Request;

namespace Course_Signup_System.Services
{
    public interface IAuthService
    {
        Task<string> Login(Login login);
    }
}

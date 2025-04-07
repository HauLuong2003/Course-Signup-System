using Course_Signup_System.Application.DTO.Request;
using Course_Signup_System.Application.DTO.Reponse;

namespace Course_Signup_System.Application.Services
{
    public interface IAuthService
    {
        Task<string> Login(Login login);
        Task<string> ForgetPassword(ForgetPassword ForgetPassword);
        Task<ServiceResponse> ResetPassword (ResetPassword ResetPassword);
        Task<bool> VerificationToken(VerificationToken VerificationToken);

    }
}

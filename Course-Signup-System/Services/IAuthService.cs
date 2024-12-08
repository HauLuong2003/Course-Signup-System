using Course_Signup_System.DTO.Reponse;
using Course_Signup_System.DTO.Request;

namespace Course_Signup_System.Services
{
    public interface IAuthService
    {
        Task<string> Login(Login login);
        Task<string> ForgetPassword(ForgetPassword ForgetPassword);
        Task<ServiceResponse> ResetPassword (ResetPassword ResetPassword);
        Task<bool> VerificationToken(VerificationToken VerificationToken);

    }
}

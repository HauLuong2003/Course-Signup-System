namespace Course_Signup_System.Services
{
    public interface IAuthService
    {
        Task<string> Login(string username, string password);
    }
}

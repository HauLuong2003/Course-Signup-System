using Course_Signup_System.Entities;

namespace Course_Signup_System.Services
{
    public interface IUserService
    {
        Task<User> CreateUser (User user);

    }
}

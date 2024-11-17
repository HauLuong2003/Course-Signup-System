using Course_Signup_System.Common;
using Course_Signup_System.Entities;

namespace Course_Signup_System.Services
{
    public interface IUserService
    {
        Task<User> CreateUser (User user);
        Task<ServiceResponse> UpdateUser (User user);
        Task<ServiceResponse> DeleteUser (string userId);
        Task<List<User>> GetUser ();
        Task<User> GetUserById (string userId);
    }
}

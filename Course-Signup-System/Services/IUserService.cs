using Course_Signup_System.Common;
using Course_Signup_System.DTO;


namespace Course_Signup_System.Services
{
    public interface IUserService
    {
        Task<UserDTO> CreateUser (UserDTO user);
        Task<ServiceResponse> UpdateUser (UserDTO user);
        Task<ServiceResponse> DeleteUser (string userId);
        Task<List<UserDTO>> GetUser ();
        Task<UserDTO> GetUserById (string userId);
    }
}

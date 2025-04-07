using Course_Signup_System.Application.DTO;
using Course_Signup_System.Application.DTO.Reponse;


namespace Course_Signup_System.Application.Services
{
    public interface IUserService
    {
        Task<UserDTO> CreateUser (UserDTO user);
        Task<ServiceResponse> UpdateUser (UserDTO user);
        Task<ServiceResponse> DeleteUser (string userId);
        Task<PageResult<UserDTO>> GetUser (int page, int pagesize);
        Task<UserDTO> GetUserById (string userId);
        Task<List<UserDTO>> GetUserByEmail (string Email);
           
    }
}

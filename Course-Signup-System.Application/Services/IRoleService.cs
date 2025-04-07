using Course_Signup_System.Domain.Entities;
using Course_Signup_System.Application.DTO.Reponse;
using Course_Signup_System.Application.DTO;
namespace Course_Signup_System.Application.Services
{
    public interface IRoleService
    {
        Task<RoleDTO> CreateRole(RoleDTO roleDTO);
        Task<ServiceResponse> UpdateRole(RoleDTO role);
        Task<ServiceResponse> DeleteRole(int Id);
        Task<RoleDTO> GetRoleById(int Id);
        Task<List<RoleDTO>> GetRoles();
    }
}

using Course_Signup_System.Common;
using Course_Signup_System.DTO;
using Course_Signup_System.Entities;

namespace Course_Signup_System.Services
{
    public interface IRoleService
    {
        Task<RoleDTO> CreateRole(RoleDTO role);
        Task<ServiceResponse> UpdateRole(RoleDTO role);
        Task<ServiceResponse> DeleteRole(int Id);
        Task<RoleDTO> GetRoleById(int Id);
        Task<List<RoleDTO>> GetRoles();
    }
}

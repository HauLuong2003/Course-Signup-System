using Course_Signup_System.Common;
using Course_Signup_System.Entities;

namespace Course_Signup_System.Services
{
    public interface IRoleService
    {
        Task<Role> CreateRole(Role role);
        Task<ServiceResponse> UpdateRole(Role role);
        Task<ServiceResponse> DeleteRole(int Id);
        Task<Role> GetRoleById(int Id);
        Task<List<Role>> GetRoles();
    }
}

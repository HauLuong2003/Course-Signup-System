using Course_Signup_System.Common;
using Course_Signup_System.Data;
using Course_Signup_System.Entities;
using Course_Signup_System.Services;
using Microsoft.EntityFrameworkCore;

namespace Course_Signup_System.Repositories
{
    public class RoleRepository : IRoleService
    {
        private readonly CourseSystemDB _courseDb;

        public RoleRepository(CourseSystemDB courseDb) 
        {
            _courseDb = courseDb;
        }
        public async Task<Role> CreateRole(Role role)
        {
           if (role == null)
           {
                throw new ArgumentNullException("Role is null");
           }
            _courseDb.Roles.Add(role);
            await _courseDb.SaveChangesAsync();
            return role;
        }

        public async Task<ServiceResponse> DeleteRole(int Id)
        {
            var roleId = await _courseDb.Roles.FindAsync(Id);
            if(roleId is null)
            {
                return new ServiceResponse(false,"Role Id is null");
            }
            _courseDb.Remove(roleId);
            await _courseDb.SaveChangesAsync();
            return new ServiceResponse(true, "Delete success");
        }

        public async Task<Role> GetRoleById(int Id)
        {
            var roleId = await _courseDb.Roles.FindAsync(Id);
            if (roleId is null)
            {
                throw new ArgumentNullException("Role Id is null");
            }
            return roleId;
        }

        public async Task<List<Role>> GetRoles()
        {
            var Roles = await _courseDb.Roles.ToListAsync();
            return Roles;
        }

        public async Task<ServiceResponse> UpdateRole(Role role)
        {
           var roleId = await _courseDb.Roles.FindAsync(role.RoleId);
           if( roleId is null)
           {
               return new ServiceResponse(false,"role Id is null");
           }
           roleId.RoleName = role.RoleName;
            await _courseDb.SaveChangesAsync();
            return new ServiceResponse(true, "update sucess");
        }
    }
}

using Course_Signup_System.Common;
using Course_Signup_System.Data;
using Course_Signup_System.Entities;
using Course_Signup_System.Services;
using Microsoft.EntityFrameworkCore;

namespace Course_Signup_System.Repositories
{
    public class UserRepository : IUserService
    {
        private readonly CourseSystemDB _courseSystemDB;
       
        public UserRepository(CourseSystemDB courseSystemDB) 
        {
            _courseSystemDB = courseSystemDB;
           
        }
        public async Task<User> CreateUser(User user)
        {      
            user.CreateAt = DateTime.Now;
            _courseSystemDB.Users.Add(user);
            await _courseSystemDB.SaveChangesAsync();
            return user;
        }

        public async Task<ServiceResponse> DeleteUser(string userId)
        {
            var user = await _courseSystemDB.Users.FindAsync(userId);
            if(user is null)
            {
                return new ServiceResponse(false, "user Id is null");
            }
            _courseSystemDB.Remove(user);
            await _courseSystemDB.SaveChangesAsync();
            return new ServiceResponse(true, "Delete success");
        }

        public async Task<List<User>> GetUser()
        {
           var users = await _courseSystemDB.Users.ToListAsync();
            return users;
        }

        public async Task<User> GetUserById(string Id)
        {
            var user = await _courseSystemDB.Users.FindAsync(Id);
            if(user is null)
            {
                throw new ArgumentNullException("user Id is null");
            }
            return user;
        }

        public async Task<ServiceResponse> UpdateUser(User user)
        {
            var u = await _courseSystemDB.Users.FindAsync(user.UserId);
            if(u is null)
            {
                return new ServiceResponse(false, "user Id is null");
            }
            u.UpdateAt = DateTime.Now;
            u.Email = user.Email;
            u.Avatar = user.Avatar;
            u.FirstName = user.FirstName;
            u.LastName = user.LastName;
            u.RoleId = user.RoleId;
            await _courseSystemDB.SaveChangesAsync();
            return new ServiceResponse(true, "Update success");
        }
    }
}

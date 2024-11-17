using AutoMapper;
using Course_Signup_System.Common;
using Course_Signup_System.Data;
using Course_Signup_System.DTO;
using Course_Signup_System.Entities;
using Course_Signup_System.Services;
using Microsoft.EntityFrameworkCore;

namespace Course_Signup_System.Repositories
{
    public class UserRepository : IUserService
    {
        private readonly CourseSystemDB _courseSystemDB;
        private readonly IMapper _mapper;
        private readonly IHashPasword _hashPasword;
        public UserRepository(CourseSystemDB courseSystemDB, IMapper mapper,IHashPasword hashPasword) 
        {
            _courseSystemDB = courseSystemDB;
            _mapper = mapper;
            _hashPasword = hashPasword;
        }
        public async Task<UserDTO> CreateUser(UserDTO userDto)
        {
            _hashPasword.CreateHashPassword(userDto.Password, out string HashPassword, out string PasswordSalt);
            var user = _mapper.Map<User>(userDto);
            user.PasswordHash = HashPassword;
            user.PasswordSalt = PasswordSalt;          
            user.CreateAt = DateTime.Now;
            _courseSystemDB.Users.Add(user);
            await _courseSystemDB.SaveChangesAsync();
            return _mapper.Map<UserDTO>(user);
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

        public async Task<List<UserDTO>> GetUser()
        {
           var users = await _courseSystemDB.Users.ToListAsync();
            return _mapper.Map<List<UserDTO>>(users);
        }

        public async Task<UserDTO> GetUserById(string Id)
        {
            var user = await _courseSystemDB.Users.FindAsync(Id);
            if(user is null)
            {
                throw new ArgumentNullException("user Id is null");
            }
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<ServiceResponse> UpdateUser(UserDTO userDTO)
        {
            var u = await _courseSystemDB.Users.FindAsync(userDTO.UserId);
            if(u is null)
            {
                return new ServiceResponse(false, "user Id is null");
            }
            var user = _mapper.Map<User>(userDTO);
          
            u.Email = user.Email;
            u.Avatar = user.Avatar;
            u.FirstName = user.FirstName;
            u.LastName = user.LastName;
            u.RoleId = user.RoleId;
            u.UpdateAt = DateTime.Now;
            await _courseSystemDB.SaveChangesAsync();
            return new ServiceResponse(true, "Update success");
        }
    }
}

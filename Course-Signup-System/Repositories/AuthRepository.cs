using Course_Signup_System.Data;
using Course_Signup_System.DTO.Request;
using Course_Signup_System.Entities;
using Course_Signup_System.Services;
using Microsoft.EntityFrameworkCore;

namespace Course_Signup_System.Repositories
{
    public class AuthRepository : IAuthService
    {
        private readonly CourseSystemDB _dbcontext;
        private readonly IHashPasword _hashPasword;
        private readonly GenerateService _generateService;
        public AuthRepository(CourseSystemDB dbcontext, IHashPasword hashPasword, GenerateService generateService)
        {
            _dbcontext = dbcontext;
            _hashPasword = hashPasword;
            _generateService = generateService;
        }
        public async Task<string> Login(Login login)
        {
            if (login.ConfirmTeacher == true)
            {
                var teacher = await _dbcontext.Users.FirstOrDefaultAsync(t => t.Email == login.Username);
                if (teacher is null) return "user name  incorrect";
                else
                {
                    if (!_hashPasword.VerifyHashPassword(login.Password, teacher.PasswordHash, teacher.PasswordSalt))
                    {
                        return "password is incorrect";
                    }
                    var jwt =  await _generateService.GenerateJwtToken(teacher);
                    return jwt;
                }         

            }
            else
            {
                var student = await _dbcontext.Users.FindAsync(login.Username);
                if(student is null) return  "code incorrect";
                else
                {
                    if (!_hashPasword.VerifyHashPassword(login.Password, student.PasswordHash, student.PasswordSalt))
                    {
                        return "password is incorrect";
                    }
                    var jwt = await _generateService.GenerateJwtToken(student);
                    return jwt;
                }
            }
        }
    }
}

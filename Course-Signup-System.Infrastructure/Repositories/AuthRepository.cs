using Course_Signup_System.Infrastructure.Data;
using Course_Signup_System.Application.DTO.Reponse;
using Course_Signup_System.Application.DTO.Request;
using Course_Signup_System.Domain.Entities;
using Course_Signup_System.Application.Services;
using Microsoft.EntityFrameworkCore;

namespace Course_Signup_System.Infrastructure.Repositories
{
    public class AuthRepository : IAuthService
    {
        private readonly CourseSystemDB _dbcontext;
        private readonly IHashPasword _hashPasword;
        private readonly IGenerateService _generateService;
        public AuthRepository(CourseSystemDB dbcontext, IHashPasword hashPasword, IGenerateService generateService)
        {
            _dbcontext = dbcontext;
            _hashPasword = hashPasword;
            _generateService = generateService;
        }

        public async Task<string> ForgetPassword(ForgetPassword ForgetPassword)
        {
            var email = await _dbcontext.Users.AnyAsync(u => u.Email == ForgetPassword.Email);
            if (email == true)
            {
                var sendemail = await _generateService.SendEmail(ForgetPassword.Email);
                if (sendemail == true)
                {
                    var jwt = await _generateService.GenerateVerificationToken(ForgetPassword.Email);
                    return jwt;
                }
                throw new Exception($"send don't successs: {sendemail}");
            }
            else
            {
                throw new Exception("Email incorrect");
            }
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
                var student = await _dbcontext.Users.FirstOrDefaultAsync(l=>l.Email == login.Username);
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

        public async Task<ServiceResponse> ResetPassword(ResetPassword ResetPassword)
        {
            var user = await _dbcontext.Users.FirstOrDefaultAsync(u => u.Email == ResetPassword.Email);
            if (user == null)
            {
                throw new Exception("user don't exist");
            }
            else if (user.VerificationCode == null)
            {
                _hashPasword.CreateHashPassword(ResetPassword.Password, out string HashPassword, out string PasswordSalte);
                user.PasswordHash = HashPassword;
                user.PasswordSalt = PasswordSalte;
                await _dbcontext.SaveChangesAsync();
                return new ServiceResponse(true, "reset password success");
            }
            return new ServiceResponse(false, "reset password don't success");

        }

        public async Task<bool> VerificationToken(VerificationToken VerificationToken)
        {
            var user = await _dbcontext.Users.FirstOrDefaultAsync(u => u.Email == VerificationToken.Email);
            if (user == null)
            {
                throw new Exception("user don't exist");
            }
            else if (user.VerificationCode == VerificationToken.Token)
            {
                user.VerificationCode = null;
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }
        

    }
}

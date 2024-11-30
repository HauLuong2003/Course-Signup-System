using Course_Signup_System.Data;
using Course_Signup_System.Entities;
using Course_Signup_System.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Course_Signup_System.Repositories
{
    public class GenerateRepository : GenerateService
    {
        private readonly CourseSystemDB _dbContext;
        private readonly IConfiguration _configuration;
        public GenerateRepository(CourseSystemDB dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }
        public async Task<string> GenerateCodeAsync()
        {
           var year = DateTime.Now.Year;
           var month = DateTime.Now.Month.ToString("D2");
           int nextNumber = 1;
            var prefix = $"{ year}{month}";
            var lastCode = await _dbContext.Users
                                   .Where(u => u.UserId.StartsWith(prefix))
                                   .OrderByDescending(u => u.UserId)
                                   .Select(u => u.UserId)
                                   .FirstOrDefaultAsync();
            if (lastCode != null)
            {
                // Tách phần số cuối cùng từ mã
                var lastNumber = int.Parse(lastCode.Split('-').Last());
                nextNumber = lastNumber + 1;
            }
            return $"{prefix}-{nextNumber.ToString("D6")}";
        }

        public async Task<string> GenerateJwtToken(User user)
        {
            var role = await _dbContext.Users.Include(u => u.Role).Where(u =>u.UserId == user.UserId).FirstOrDefaultAsync();
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Role, role!.Role.RoleName),
                new Claim(ClaimTypes.NameIdentifier,user.UserId)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSetting:Token").Value));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var token = new JwtSecurityToken(claims: claims,
                            signingCredentials: credentials,
                            expires: DateTime.Now.AddMinutes(30));
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

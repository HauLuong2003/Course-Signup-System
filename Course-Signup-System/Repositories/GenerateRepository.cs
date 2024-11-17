using Course_Signup_System.Data;
using Course_Signup_System.Services;
using Microsoft.EntityFrameworkCore;

namespace Course_Signup_System.Repositories
{
    public class GenerateRepository : GenerateService
    {
        private readonly CourseSystemDB _dbContext;
        public GenerateRepository(CourseSystemDB dbContext)
        {
            _dbContext = dbContext;
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
    }
}

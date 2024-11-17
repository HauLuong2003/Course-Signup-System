using Course_Signup_System.Common;
using Course_Signup_System.Data;
using Course_Signup_System.Entities;
using Course_Signup_System.Services;
using Microsoft.EntityFrameworkCore;

namespace Course_Signup_System.Repositories
{
    public class StudentRepository : IStudentService
    {
        private readonly CourseSystemDB _courseSystemDB;
        private readonly GenerateService _generateService;
        public StudentRepository(CourseSystemDB courseSystemDB, GenerateService generateService)
        {
            _courseSystemDB = courseSystemDB;
            _generateService = generateService;
        }
        public async Task<Student> CreateStudent(Student student)
        {
            var code = await _generateService.GenerateCodeAsync();
            student.UserId = code;
            student.CreateAt = DateTime.Now;
            await _courseSystemDB.Students.AddAsync(student);
            await _courseSystemDB.SaveChangesAsync();
            return student;
        }

        public async Task<ServiceResponse> DeleteStudent(string Id)
        {
            var student = await _courseSystemDB.Users.FindAsync(Id);
            if (student is null)
            {
                return new ServiceResponse(false, "student is null");
            }
            _courseSystemDB.Users.Remove(student);
            await _courseSystemDB.SaveChangesAsync();
            return new ServiceResponse(true, "Delete success");
        }

        public async Task<List<Student>> GetAllStudents()
        {
            var students = await _courseSystemDB.Students.ToListAsync();
            return students;
        }

        public async Task<Student> GetStudentById(string Id)
        {
            var studentId = await _courseSystemDB.Students.FindAsync(Id);
            if (studentId is null)
            {
               throw new ArgumentNullException ("Student Id is null");
            }
            return studentId;
        }

        public async Task<ServiceResponse> UpdateStudent(Student student)
        {
            var studentId = await _courseSystemDB.Students.FindAsync(student.UserId);
            if (studentId is null)
            {
                return new ServiceResponse(false,"Student Id is null");
            }
            studentId.Sex = student.Sex;
            studentId.Email = student.Email;
            studentId.FirstName = student.FirstName;
            studentId.LastName = student.LastName;
            studentId.PhoneNumber = student.PhoneNumber;
            studentId.Avatar = student.Avatar;
            studentId.Address = student.Address;
            studentId.BirthDay = student.BirthDay;
            studentId.UpdateAt = DateTime.Now;
            await _courseSystemDB.SaveChangesAsync();
            return new ServiceResponse(true, "Update success");
        }
    }
}

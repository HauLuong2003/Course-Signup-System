using AutoMapper;
using Course_Signup_System.Common;
using Course_Signup_System.Data;
using Course_Signup_System.DTO;
using Course_Signup_System.Entities;
using Course_Signup_System.Services;
using Microsoft.EntityFrameworkCore;

namespace Course_Signup_System.Repositories
{
    public class StudentRepository : IStudentService
    {
        private readonly CourseSystemDB _courseSystemDB;
        private readonly GenerateService _generateService;
        private readonly IMapper _mapper;
        private readonly IHashPasword _hashPasword;
        public StudentRepository(CourseSystemDB courseSystemDB, GenerateService generateService, IMapper mapper, IHashPasword hashPasword)
        {
            _courseSystemDB = courseSystemDB;
            _generateService = generateService;
            _mapper = mapper;
            _hashPasword = hashPasword;
        }
        public async Task<StudentDTO> CreateStudent(StudentDTO student)
        {
           _hashPasword.CreateHashPassword(student.Password, out string HashPassword, out string PasswordSalt);
            var code = await _generateService.GenerateCodeAsync();
            var students = _mapper.Map<Student>(student);
            students.UserId = code;
            students.CreateAt = DateTime.Now;

            students.PasswordHash = HashPassword;
            students.PasswordSalt = PasswordSalt;
            await _courseSystemDB.Students.AddAsync(students);
            await _courseSystemDB.SaveChangesAsync();
            return _mapper.Map<StudentDTO>(students);
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

        public async Task<List<StudentDTO>> GetAllStudents()
        {
            var students = await _courseSystemDB.Students.ToListAsync();
            return _mapper.Map<List<StudentDTO>>(students);
            
        }

        public async Task<StudentDTO> GetStudentById(string Id)
        {
            var studentId = await _courseSystemDB.Students.FindAsync(Id);
            if (studentId is null)
            {
               throw new ArgumentNullException ("Student Id is null");
            }
            return _mapper.Map<StudentDTO>(studentId);
             
        }

        public async Task<ServiceResponse> UpdateStudent(StudentDTO student)
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

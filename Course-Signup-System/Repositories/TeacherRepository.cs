using AutoMapper;
using Course_Signup_System.Common;
using Course_Signup_System.Data;
using Course_Signup_System.DTO;
using Course_Signup_System.Entities;
using Course_Signup_System.Services;
using Microsoft.EntityFrameworkCore;

namespace Course_Signup_System.Repositories
{
    public class TeacherRepository : ITeacherService
    {
        private readonly CourseSystemDB _courseSystemDB;
        private readonly IMapper _mapper;
        private readonly IHashPasword _hashPasword;
        public TeacherRepository(CourseSystemDB courseSystemDB, IMapper mapper, IHashPasword hashPasword)
        {
            _courseSystemDB = courseSystemDB;
            _mapper = mapper;
            _hashPasword = hashPasword;
        }

        public async Task<TeacherDTO> CreateTeacher(TeacherDTO teacherdto)
        {
            _hashPasword.CreateHashPassword(teacherdto.Password, out string HashPassword, out string PasswordSalt);
            var teacher = _mapper.Map<Teacher>(teacherdto);
            teacher.PasswordHash = HashPassword;
            teacher.PasswordSalt = PasswordSalt;            
            teacher.CreateAt = DateTime.Now;
            teacher.UpdateAt = DateTime.Now;
            _courseSystemDB.Teachers.Add(teacher);
            await _courseSystemDB.SaveChangesAsync();
            return _mapper.Map<TeacherDTO>(teacher);
        }

        public async Task<ServiceResponse> DeleteTeacher(string Id)
        {
            var teacher = await _courseSystemDB.Teachers.FindAsync(Id);
            if (teacher == null)
            {
                return new ServiceResponse(false, "teacher id is null");
            }
            _courseSystemDB.Users.Remove(teacher);
            await _courseSystemDB.SaveChangesAsync();
            return new ServiceResponse(true, "delete success");
        }

        public async Task<List<TeacherDTO>> GetAllTeachers()
        {
            var teachers = await _courseSystemDB.Teachers.ToListAsync();
            return _mapper.Map<List<TeacherDTO>>(teachers);
        }

        public async Task<TeacherDTO> GetTeacherById(string id)
        {
            var teacher = await _courseSystemDB.Teachers.FindAsync(id);
            if (teacher is null)
            {
                throw new ArgumentException("Teacher id is null");
            }
            return _mapper.Map<TeacherDTO>(teacher);
        }

        public async Task<ServiceResponse> UpdateTeacher(TeacherDTO teacherdto)
        {
            var teacherId = await _courseSystemDB.Teachers.FindAsync(teacherdto.UserId);
            if (teacherId is null)
            {
                return new ServiceResponse(false, "teacher Id is null");
            }
            var teacher = _mapper.Map<Teacher>(teacherdto);
            teacherId.Sex = teacher.Sex;
            teacherId.Email = teacher.Email;
            teacherId.FirstName = teacher.FirstName;
            teacherId.LastName = teacher.LastName;
            teacherId.PhoneNumber = teacher.PhoneNumber;
            teacherId.Avatar = teacher.Avatar;
            teacherId.Address = teacher.Address;
            teacherId.BirthDay = teacher.BirthDay;
            teacherId.UpdateAt = DateTime.Now;
            await _courseSystemDB.SaveChangesAsync();
            return new ServiceResponse(true, "Update success");
        }
    }
}

using Course_Signup_System.Common;
using Course_Signup_System.Data;
using Course_Signup_System.Entities;
using Course_Signup_System.Services;
using Microsoft.EntityFrameworkCore;

namespace Course_Signup_System.Repositories
{
    public class TeacherRepository : ITeacherService
    {
        private readonly CourseSystemDB _courseSystemDB;
        public TeacherRepository(CourseSystemDB courseSystemDB)
        {
            _courseSystemDB = courseSystemDB;
        }

        public async Task<Teacher> CreateTeacher(Teacher teacher)
        {
            teacher.CreateAt = DateTime.Now;
            teacher.UpdateAt = DateTime.Now;
            _courseSystemDB.Teachers.Add(teacher);
            await _courseSystemDB.SaveChangesAsync();
            return teacher;
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

        public async Task<List<Teacher>> GetAllTeachers()
        {
            var teachers = await _courseSystemDB.Teachers.ToListAsync();
            return teachers;
        }

        public async Task<Teacher> GetTeacherById(string id)
        {
            var teacher = await _courseSystemDB.Teachers.FindAsync(id);
            if (teacher is null)
            {
                throw new ArgumentException("Teacher id is null");
            }
            return teacher;
        }

        public async Task<ServiceResponse> UpdateTeacher(Teacher teacher)
        {
            var teacherId = await _courseSystemDB.Teachers.FindAsync(teacher.UserId);
            if (teacherId is null)
            {
                return new ServiceResponse(false, "teacher Id is null");
            }
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

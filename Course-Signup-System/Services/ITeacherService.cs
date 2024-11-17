using Course_Signup_System.Common;
using Course_Signup_System.Entities;

namespace Course_Signup_System.Services
{
    public interface ITeacherService
    {
        Task<Teacher> GetTeacherById(string id);
        Task<Teacher> CreateTeacher(Teacher teacher);
        Task<ServiceResponse> UpdateTeacher(Teacher teacher);
        Task<ServiceResponse> DeleteTeacher(string Id);
        Task<List<Teacher>> GetAllTeachers();
    }
}

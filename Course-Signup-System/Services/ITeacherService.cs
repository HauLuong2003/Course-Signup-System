using Course_Signup_System.Common;
using Course_Signup_System.DTO;
using Course_Signup_System.Entities;

namespace Course_Signup_System.Services
{
    public interface ITeacherService
    {
        Task<TeacherDTO> GetTeacherById(string id);
        Task<TeacherDTO> CreateTeacher(TeacherDTO teacher);
        Task<ServiceResponse> UpdateTeacher(TeacherDTO teacher);
        Task<ServiceResponse> DeleteTeacher(string Id);
        Task<List<TeacherDTO>> GetAllTeachers();
    }
}

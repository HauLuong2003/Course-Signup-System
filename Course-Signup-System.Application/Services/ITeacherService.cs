using Course_Signup_System.Application.DTO;
using Course_Signup_System.Application.DTO.Reponse;

namespace Course_Signup_System.Application.Services
{
    public interface ITeacherService
    {
        Task<TeacherDTO> GetTeacherById(string id);
        Task<ServiceResponse> CreateTeacher(TeacherDTO teacher);
        Task<ServiceResponse> UpdateTeacher(TeacherDTO teacher);
        Task<ServiceResponse> DeleteTeacher(string Id);
        Task<PageResult<TeacherDTO>> GetAllTeachers(int page, int pagesize);
        Task<TeacherDTO> GetTeacherByEmail(string Email);
        Task<List<TeacherDTO>> SearchTeacher(string Name);
        Task<TeacherSalary> GetSalaryOfTeacher( string TeacherId);
    }
}

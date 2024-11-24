using Course_Signup_System.DTO;
using Course_Signup_System.DTO.Reponse;

namespace Course_Signup_System.Services
{
    public interface ITeacherService
    {
        Task<TeacherDTO> GetTeacherById(string id);
        Task<TeacherDTO> CreateTeacher(TeacherDTO teacher);
        Task<ServiceResponse> UpdateTeacher(TeacherDTO teacher);
        Task<ServiceResponse> DeleteTeacher(string Id);
        Task<PageResult<TeacherDTO>> GetAllTeachers(int page, int pagesize);
        Task<List<TeacherDTO>> GetTeacherByEmail(string Email);
        Task<List<TeacherDTO>> SearchTeacher(string Name);
    }
}

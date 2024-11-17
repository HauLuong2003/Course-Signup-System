using Course_Signup_System.Common;
using Course_Signup_System.DTO;
using Course_Signup_System.Entities;

namespace Course_Signup_System.Services
{
    public interface IStudentService
    {
        Task<StudentDTO> GetStudentById(string id);
        Task<StudentDTO> CreateStudent(StudentDTO student);
        Task<ServiceResponse> UpdateStudent(StudentDTO student);
        Task<ServiceResponse> DeleteStudent(string Id);
        Task<List<StudentDTO>> GetAllStudents();
    }
}

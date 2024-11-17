using Course_Signup_System.Common;
using Course_Signup_System.Entities;

namespace Course_Signup_System.Services
{
    public interface IStudentService
    {
        Task<Student> GetStudentById(string id);
        Task<Student> CreateStudent(Student student);
        Task<ServiceResponse> UpdateStudent(Student student);
        Task<ServiceResponse> DeleteStudent(string Id);
        Task<List<Student>> GetAllStudents();
    }
}

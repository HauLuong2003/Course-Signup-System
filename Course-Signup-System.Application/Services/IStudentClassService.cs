using Course_Signup_System.Application.DTO;
using Course_Signup_System.Application.DTO.Reponse;

namespace Course_Signup_System.Application.Services
{
    public interface IStudentClassService
    {
        Task<StudentClassDTO> CreateStudentClass(StudentClassDTO studentClassDTO);
        Task<ServiceResponse> UpdateStudentClass(int Id,StudentClassDTO studentClassDTO);
        Task<PageResult<StudentClassDTO>> GetStudentClasses(int page, int pagesize);
        Task<ServiceResponse> DeleteStudentClass(int StudentClassId);
        Task<StudentClassDTO> GetStudentClassById(int StudentClassId);
        Task<List<StudentClassDTO>> GetStudentByStatus(bool status);
        Task<ServiceResponse> CheckPayTuition(string StudentId, string ClassId);
        
    }
}

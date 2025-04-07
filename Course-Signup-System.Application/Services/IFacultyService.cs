using Course_Signup_System.Application.DTO;
using Course_Signup_System.Application.DTO.Reponse;

namespace Course_Signup_System.Application.Services
{
    public interface IFacultyService
    {
        Task<FacultyDTO> CreateFaculty(FacultyDTO facultyDTO);
        Task<PageResult<FacultyDTO>> GetAllFaculty(int page,int pagesize);
        Task<ServiceResponse> DeleteFaculty(string facultyId);
        Task<FacultyDTO> GetFacultyById(string facultyId);
        Task<ServiceResponse> UpdateFaculty(FacultyDTO facultyDTO);
    }
}

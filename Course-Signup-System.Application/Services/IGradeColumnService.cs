using Course_Signup_System.Application.DTO.Reponse;
using Course_Signup_System.Application.DTO;

namespace Course_Signup_System.Application.Services
{
    public interface IGradeColumnService
    {
        Task<GradeColumnDTO> CreateGrade(GradeColumnDTO GradeColumnDTO);
        Task<ServiceResponse> UpdateGrade(int Id, GradeColumnDTO GradeColumnDTO);
        Task<List<GradeColumnDTO>> GetGrade();
        Task<ServiceResponse> DeleteGradeType(int GradeColumnId);
        Task<GradeColumnDTO> GetGradeById(int GradeColumnId);
    }
}

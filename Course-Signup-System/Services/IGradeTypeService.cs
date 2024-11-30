using Course_Signup_System.DTO.Reponse;
using Course_Signup_System.DTO;

namespace Course_Signup_System.Services
{
    public interface IGradeTypeService
    {
        Task<GradeTypeDTO> CreateGradeType(GradeTypeDTO GradeTypeDTO);
        Task<ServiceResponse> UpdateGradeType(int Id, GradeTypeDTO GradeTypeDTO);
        Task<PageResult<GradeTypeDTO>> GetGradeType(int page, int pagesize);
        Task<ServiceResponse> DeleteGradeType(int GradeTypeId);
        Task<GradeTypeDTO> GetGradeTypeById(int GradeTypeId);
    }
}

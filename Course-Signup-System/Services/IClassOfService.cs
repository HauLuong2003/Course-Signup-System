using Course_Signup_System.DTO.Reponse;
using Course_Signup_System.DTO;

namespace Course_Signup_System.Services
{
    public interface IClassOfService
    {
        Task<ClassOfDTO> CreateClassOf(ClassOfDTO classDTO);
        Task<PageResult<ClassOfDTO>> GetAllClassOf(int page, int pagesize);
        Task<ServiceResponse> DeleteClassOf(string ClassOfId);
        Task<ClassOfDTO> GetClassOfById(string ClassId);
        Task<ServiceResponse> UpdateClassOf(ClassOfDTO ClassOfDTO);
    }
}

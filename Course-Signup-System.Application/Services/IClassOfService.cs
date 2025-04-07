using Course_Signup_System.Application.DTO;
using Course_Signup_System.Application.DTO.Reponse;
namespace Course_Signup_System.Application.Services
{
    public interface IClassOfService
    {
        Task<ClassOfDTO> CreateClassOf(ClassOfDTO classofDTO);
        Task<PageResult<ClassOfDTO>> GetAllClassOf(int page, int pagesize);
        Task<ServiceResponse> DeleteClassOf(string ClassOfId);
        Task<ClassOfDTO> GetClassOfById(string ClassId);
        Task<ServiceResponse> UpdateClassOf(ClassOfDTO ClassOfDTO);
    }
}

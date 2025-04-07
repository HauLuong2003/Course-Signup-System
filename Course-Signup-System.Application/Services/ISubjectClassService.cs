using Course_Signup_System.Domain.Entities;
using Course_Signup_System.Application.DTO;
using Course_Signup_System.Application.DTO.Reponse;
namespace Course_Signup_System.Application.Services
{
    public interface ISubjectClassService
    {
        Task<SubjectClassDTO> CreateSubjectClass(SubjectClassDTO SubjectClassDTO);
        Task<ServiceResponse> UpdateSubjectClass(int Id, SubjectClassDTO SubjectClassDTO);
        Task<PageResult<SubjectClassDTO>> GetSubjectClass(int page, int pagesize);
        Task<ServiceResponse> DeleteSubjectClass(int SubjectClassId);
        Task<SubjectClassDTO> GetSubjectClassById(int SubjectClassId);
    }
}

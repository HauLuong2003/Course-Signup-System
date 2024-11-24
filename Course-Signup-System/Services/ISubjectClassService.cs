using Course_Signup_System.DTO.Reponse;
using Course_Signup_System.DTO;

namespace Course_Signup_System.Services
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

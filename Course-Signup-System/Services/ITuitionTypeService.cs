using Course_Signup_System.DTO.Reponse;
using Course_Signup_System.DTO;

namespace Course_Signup_System.Services
{
    public interface ITuitionTypeService
    {
        Task<TuitionTypeDTO> CreateTuitionType(TuitionTypeDTO TuitionTypeDTO);
        Task<ServiceResponse> UpdateTuitionType(int Id, TuitionTypeDTO TuitionTypeDTO);
        Task<List<TuitionTypeDTO>> GetTuitionType();
        Task<ServiceResponse> DeleteTuitionType(int TuitionTypeId);
        Task<TuitionTypeDTO> GetTuitionTypeById(int TuitionTypeId);
    }
}

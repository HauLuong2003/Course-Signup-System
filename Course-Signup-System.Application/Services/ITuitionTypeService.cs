using Course_Signup_System.Application.DTO;
using Course_Signup_System.Application.DTO.Reponse;

namespace Course_Signup_System.Application.Services
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

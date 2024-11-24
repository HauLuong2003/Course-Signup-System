using Course_Signup_System.DTO.Reponse;
using Course_Signup_System.DTO;

namespace Course_Signup_System.Services
{
    public interface ITeacherScheduleService
    {
        Task<TeacherScheduleDTO> CreateTeacherSchedule(TeacherScheduleDTO TeacherScheduleDTO);
        Task<ServiceResponse> UpdateTeacherSchedule(int Id, TeacherScheduleDTO TeacherScheduleDTO);
        Task<PageResult<TeacherScheduleDTO>> GetTeacherSchedule(int page, int pagesize);
        Task<ServiceResponse> DeleteTeacherSchedule(int TeacherScheduleId);
        Task<TeacherScheduleDTO> GetTeacherScheduleById(int TeacherScheduleId);
    }
}

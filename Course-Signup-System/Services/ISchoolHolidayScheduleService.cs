using Course_Signup_System.DTO;
using Course_Signup_System.DTO.Reponse;

namespace Course_Signup_System.Services
{
    public interface ISchoolHolidayScheduleService
    {
        Task<SchoolHolidayScheduleDTO> CreateSchoolHolidaySchedule(SchoolHolidayScheduleDTO schoolHolidayScheduleDTO);
        Task<ServiceResponse> UpdateSchoolHolidaySchedule(SchoolHolidayScheduleDTO schoolHolidayScheduleDTO);
        Task<ServiceResponse> DeleteSchoolHolidaySchedule(int Id);
        Task<SchoolHolidayScheduleDTO> GetSchoolHolidaySchedule(int Id);
        Task<List<SchoolHolidayScheduleDTO>> GetAllSchoolHolidaySchedules();
    }
}

using Course_Signup_System.Domain.Entities;
using Course_Signup_System.Application.DTO.Reponse;
using Course_Signup_System.Application.DTO;
namespace Course_Signup_System.Application.Services
{
    public interface ISchoolHolidayScheduleService
    {
        Task<SchoolHolidayScheduleDTO> CreateSchoolHolidaySchedule(SchoolHolidayScheduleDTO schoolHolidaySchedule);
        Task<ServiceResponse> UpdateSchoolHolidaySchedule(SchoolHolidayScheduleDTO schoolHolidayScheduleDTO);
        Task<ServiceResponse> DeleteSchoolHolidaySchedule(int Id);
        Task<SchoolHolidayScheduleDTO> GetSchoolHolidaySchedule(int Id);
        Task<List<SchoolHolidayScheduleDTO>> GetAllSchoolHolidaySchedules();
    }
}

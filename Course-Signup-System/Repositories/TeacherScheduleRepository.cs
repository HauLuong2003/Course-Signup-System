using AutoMapper;
using Course_Signup_System.Data;
using Course_Signup_System.DTO;
using Course_Signup_System.DTO.Reponse;
using Course_Signup_System.Services;

namespace Course_Signup_System.Repositories
{
    public class TeacherScheduleRepository : ITeacherScheduleService
    {
        private readonly IMapper _mapper;
        private readonly CourseSystemDB _courseSystemDB;
        public TeacherScheduleRepository(IMapper mapper, CourseSystemDB courseSystemDB)
        {
            _mapper = mapper;
            _courseSystemDB = courseSystemDB;
        }

        public Task<TeacherScheduleDTO> CreateTeacherSchedule(TeacherScheduleDTO TeacherScheduleDTO)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse> DeleteTeacherSchedule(int TeacherScheduleId)
        {
            throw new NotImplementedException();
        }

        public Task<List<TeacherScheduleDTO>> GetTeacherSchedule()
        {
            throw new NotImplementedException();
        }

        public Task<TeacherScheduleDTO> GetTeacherScheduleById(int TeacherScheduleId)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse> UpdateTeacherSchedule(int Id, TeacherScheduleDTO TeacherScheduleDTO)
        {
            throw new NotImplementedException();
        }
    }
}

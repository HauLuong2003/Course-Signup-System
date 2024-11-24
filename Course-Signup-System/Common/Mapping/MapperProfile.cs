using AutoMapper;
using Course_Signup_System.DTO;
using Course_Signup_System.Entities;
using Course_Signup_System.Services;

namespace Course_Signup_System.Common.Mapping
{
    public class MapperProfile : Profile
    {    
        public MapperProfile()
        {           
            CreateMap<UserDTO, User>();
            CreateMap<User, UserDTO>().ForMember(dest => dest.Password, opt => opt.Ignore()); // Không ánh xạ Password từ User sang UserDTO; 
            CreateMap<Teacher, TeacherDTO>();
            CreateMap<TeacherDTO, Teacher>();
            CreateMap<StudentDTO, Student>();
            CreateMap<Student, StudentDTO>();
            CreateMap<RoleDTO, Role>();
            CreateMap<Role, RoleDTO>();
            CreateMap<ClassOf, ClassOfDTO>();
            CreateMap<ClassOfDTO, ClassOf>();
            CreateMap<ClassDTO, Class>();
            CreateMap<Class, ClassDTO>();
            CreateMap<Faculty, FacultyDTO>();
            CreateMap<FacultyDTO,Faculty>();
            CreateMap<StudentClass, StudentClassDTO>();
            CreateMap< StudentClassDTO, StudentClass>();
            CreateMap<Subject, SubjectDTO>();
            CreateMap<SubjectDTO, Subject>();
            CreateMap<SubjectClassDTO, SubjectClass>();
            CreateMap<SubjectClass, SubjectClassDTO>();
            CreateMap<TeachSchedule, TeacherScheduleDTO>();
            CreateMap<TeacherScheduleDTO, TeachSchedule>();
        }
    }
}

﻿using AutoMapper;
using Course_Signup_System.Application.DTO;
using Course_Signup_System.Domain.Entities;
using Course_Signup_System.Application.Services;

namespace Course_Signup_System.Application.Common.Mapping
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
            CreateMap<StudentClassDTO, StudentClass>();
            CreateMap<Subject, SubjectDTO>();
            CreateMap<SubjectDTO, Subject>();
            CreateMap<SubjectClassDTO, SubjectClass>();
            CreateMap<SubjectClass, SubjectClassDTO>();
            CreateMap<TeachSchedule, TeacherScheduleDTO>();
            CreateMap<TeacherScheduleDTO, TeachSchedule>();
            CreateMap<TuitionType, TuitionTypeDTO>();
            CreateMap<TuitionTypeDTO, TuitionType>();
            CreateMap<PayTuition, PaytuitionDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.StudentClass.Student.LastName + " " + src.StudentClass.Student.FirstName))
                .ForMember(dest => dest.ClassName, opt => opt.MapFrom(src => src.StudentClass.Class.ClassName));
            CreateMap<PaytuitionDTO, PayTuition>();
            CreateMap<GradeTypeDTO, GradeType>();
            CreateMap<GradeType, GradeTypeDTO>();
            CreateMap<Grade,GradeDTO>();
            CreateMap<GradeDTO, Grade>();
            CreateMap<GradeColumnDTO, GradeColumn>();
            CreateMap<GradeColumn, GradeColumnDTO>();
            CreateMap<SchoolHolidayScheduleDTO, SchoolHolidaySchedule>();
            CreateMap<SchoolHolidaySchedule,SchoolHolidayScheduleDTO>();
            CreateMap<EmployeeSalaryDTO, EmployeeSalary>();
            CreateMap<EmployeeSalary, EmployeeSalaryDTO>();
            CreateMap<Department, DepartmentDTO>();
            CreateMap<DepartmentDTO, Department>();
            CreateMap<SubjectGradeType, SubjectGradeTypeDTO>()
                .ForMember(dest => dest.GradeTypeName, opt => opt.MapFrom(src =>src.GradeType.GradeTypeName))
                .ForMember(dest=>dest.SubjectName, opt => opt.MapFrom(src => src.Subject.SubjectName))
                .ForMember(dest => dest.ClassOfName, opt => opt.MapFrom(src => src.ClassOf.ClassOfName));
            CreateMap<SubjectGradeTypeDTO, SubjectGradeType>();
            CreateMap<PermissionDTO, Permission>();
            CreateMap<Permission, PermissionDTO>();
            CreateMap<RolePermissionDTO, RolePermission>();
            CreateMap<RolePermission, RolePermissionDTO>();
        }
    }
}

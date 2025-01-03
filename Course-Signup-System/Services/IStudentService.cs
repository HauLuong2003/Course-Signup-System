﻿using Course_Signup_System.DTO;
using Course_Signup_System.DTO.Reponse;
using Course_Signup_System.Entities;

namespace Course_Signup_System.Services
{
    public interface IStudentService
    {
        Task<StudentDTO> GetStudentById(string id);
        Task<StudentDTO> CreateStudent(StudentDTO student);
        Task<ServiceResponse> UpdateStudent(StudentDTO student);
        Task<ServiceResponse> DeleteStudent(string Id);
        Task<PageResult<StudentDTO>> GetAllStudents(int page, int pagesize);
        Task<List<StudentDTO>> GetStudentByEmail(string Email);
        Task<List<StudentDTO>> SearchStudent(string Name);
        Task<List<TeachSchedule>> GetScheduleClass(string StudentId);

    }
}

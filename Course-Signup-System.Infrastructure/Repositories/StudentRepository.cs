﻿using AutoMapper;
using Course_Signup_System.Infrastructure.Data;
using Course_Signup_System.Application.DTO;
using Course_Signup_System.Application.DTO.Reponse;
using Course_Signup_System.Domain.Entities;
using Course_Signup_System.Application.Services;
using Microsoft.EntityFrameworkCore;

namespace Course_Signup_System.Infrastructure.Repositories
{
    public class StudentRepository : IStudentService
    {
        private readonly CourseSystemDB _courseSystemDB;
        private readonly IGenerateService _generateService;
        private readonly IMapper _mapper;
        private readonly IHashPasword _hashPasword;
        public StudentRepository(CourseSystemDB courseSystemDB, IGenerateService generateService, IMapper mapper, IHashPasword hashPasword)
        {
            _courseSystemDB = courseSystemDB;
            _generateService = generateService;
            _mapper = mapper;
            _hashPasword = hashPasword;
        }
        public async Task<ServiceResponse> CreateStudent(StudentDTO student)
        {
           _hashPasword.CreateHashPassword(student.Password, out string HashPassword, out string PasswordSalt);
            var code = await _generateService.GenerateCodeAsync();
            var students = _mapper.Map<Student>(student);
            students.UserId = code;
            students.CreateAt = DateTime.Now;
            students.UpdateAt = DateTime.Now;
            students.PasswordHash = HashPassword;
            students.PasswordSalt = PasswordSalt;
            await _courseSystemDB.Students.AddAsync(students);
            await _courseSystemDB.SaveChangesAsync();
            return new ServiceResponse(true,"Create success");
        }

        public async Task<ServiceResponse> DeleteStudent(string Id)
        {
            var student = await _courseSystemDB.Students.FindAsync(Id);
            if (student is null)
            {
                return new ServiceResponse(false, "student is null");
            }
            _courseSystemDB.Students.Remove(student);
            await _courseSystemDB.SaveChangesAsync();
            return new ServiceResponse(true, "Delete success");
        }

        public async Task<PageResult<StudentDTO>> GetAllStudents(int page, int pagesize)
        {
            //lấy toàn bộ student dưới dạng queryable
            var query =  _courseSystemDB.Students.AsQueryable();
            //lấy số lượng
            var count = await query.CountAsync();
            var student = await query.Skip((page - 1) * pagesize)
                                     .Take(pagesize).ToListAsync();
            var students = _mapper.Map<List<StudentDTO>>(student);

            return new PageResult<StudentDTO>
            {
                Page = page,
                PageSize = pagesize,
                TotalPages = (int) Math.Ceiling(count / (double)pagesize),
                TotalRecoreds = count,
                Data = students
            } ;
            
        }

        public async Task<StudentDTO> GetStudentById(string Id)
        {
            var studentId = await _courseSystemDB.Students.FindAsync(Id);
            if (studentId is null)
            {
               throw new ArgumentNullException ("Student Id is null");
            }
            return _mapper.Map<StudentDTO>(studentId);
             
        }

        public async Task<List<StudentDTO>> GetStudentByEmail(string Email)
        {
            var student = await _courseSystemDB.Students.Where(r => r.Email == Email).ToListAsync();
            if(student is null)
            {
                throw  new ArgumentNullException("stdent is null");
            }
            return _mapper.Map<List<StudentDTO>>(student);  

        }

        public async Task<ServiceResponse> UpdateStudent(StudentDTO student)
        {
            var studentId = await _courseSystemDB.Students.FindAsync(student.UserId);
            if (studentId is null)
            {
                return new ServiceResponse(false,"Student Id is null");
            }
            studentId.Sex = student.Sex;
            studentId.Email = student.Email;
            studentId.FirstName = student.FirstName;
            studentId.LastName = student.LastName;
            studentId.PhoneNumber = student.PhoneNumber;
            studentId.Avatar = student.Avatar;
            studentId.Address = student.Address;
            studentId.BirthDay = student.BirthDay;
            studentId.UpdateAt = DateTime.Now;
            await _courseSystemDB.SaveChangesAsync();
            return new ServiceResponse(true, "Update success");
        }

        public async Task<List<StudentDTO>> SearchStudent(string Name)
        {
            var students = await _courseSystemDB.Students.Where(t =>
               (t.LastName + " " + t.FirstName).Contains(Name)).ToListAsync();
            // if( teachers)
            return _mapper.Map<List<StudentDTO>>(students);
        }

        public async Task<List<TeacherScheduleDTO>> GetScheduleClass(string StudentId)
        {
            var schedule = await _courseSystemDB.StudentClasses.Where(st => st.UserId == StudentId && st.Status)
                                                                .SelectMany(sc => sc.Class.TeachSchedules)
                                                                .Select(ts => new TeachSchedule
                                                                {
                                                                    StudyTime = ts.StudyTime,
                                                                    StudyDay = ts.StudyDay,
                                                                    StartTime = ts.StartTime,
                                                                    EndTime = ts.EndTime,
                                                                    ClassId = ts.Class.ClassId,
                                                                    UserId = ts.Teacher.UserId,
                                                                    SubjectId = ts.Subject.SubjectId,
                                                                })
                                                                .ToListAsync();
            if(schedule == null)
            {
                throw new Exception("schedule is null");
            }
            return _mapper.Map<List<TeacherScheduleDTO>>(schedule);
        }
    }
}

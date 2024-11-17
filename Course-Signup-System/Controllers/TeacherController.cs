using AutoMapper;
using Course_Signup_System.DTO;
using Course_Signup_System.Entities;
using Course_Signup_System.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Course_Signup_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _teacherService;
        private readonly IMapper _mappper;
        private readonly IHashPasword _hashPasword;
        public TeacherController(ITeacherService teacherService, IMapper mappper, IHashPasword hashPasword)
        {
            _teacherService = teacherService;
            _mappper = mappper;
            _hashPasword = hashPasword;
        }
        [HttpGet]
        public async Task<IActionResult> GetTeachers()
        {
            try
            {
                var teachers = await _teacherService.GetAllTeachers();
                var t = _mappper.Map<List<TeacherDTO>>(teachers);
                return Ok(t);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("Id")]
        public async Task<IActionResult> GetTeacher(string Id)
        {
            try
            {
                var teacher = await _teacherService.GetTeacherById(Id);
                var Teacher = _mappper.Map<List<TeacherDTO>>(teacher);
                return Ok(Teacher);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateStudent(TeacherDTO teacherDTO)
        {
            try
            {
                _hashPasword.CreateHashPassword(teacherDTO.Password, out string HashPassword, out string PasswordSalt);
                var teacher = _mappper.Map<Teacher>(teacherDTO);
                teacher.PasswordHash = HashPassword;
                teacher.PasswordSalt = PasswordSalt;
                var st = await _teacherService.CreateTeacher(teacher);
                var s = _mappper.Map<TeacherDTO>(st);
                return Ok(s);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("Id")]
        public async Task<IActionResult> DeleteStudent(string Id)
        {
            try
            {
                var student = await _teacherService.DeleteTeacher(Id);
                return Ok(student);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("Id")]
        public async Task<IActionResult> UpdateStudent(TeacherDTO teacherDTO)
        {
            try
            {
                var st = _mappper.Map<Teacher>(teacherDTO);
                var student = await _teacherService.UpdateTeacher(st);
                return Ok(student);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}


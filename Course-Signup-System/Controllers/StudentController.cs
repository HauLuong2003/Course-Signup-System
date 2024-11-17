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
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mappper;
        private readonly IHashPasword _hashPasword;
        public StudentController(IStudentService studentService, IMapper mappper, IHashPasword hashPasword)
        {
            _studentService = studentService;
            _mappper = mappper;
            _hashPasword = hashPasword;
        }
        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            try
            {
                var students = await _studentService.GetAllStudents();
                var Students = _mappper.Map<List<StudentDTO>>(students);
                return Ok(Students);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("Id")]
        public async Task<IActionResult> GetStudents(string Id)
        {
            try
            {
                var students = await _studentService.GetStudentById(Id);
                var Students = _mappper.Map<List<StudentDTO>>(students);
                return Ok(Students);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateStudent(StudentDTO studentDTO)
        {
            try
            {
                _hashPasword.CreateHashPassword(studentDTO.Password, out string HashPassword, out string PasswordSalt);
                var student = _mappper.Map<Student>(studentDTO);              
                student.PasswordHash = HashPassword;
                student.PasswordSalt = PasswordSalt;
                var st = await _studentService.CreateStudent(student);
                var s = _mappper.Map<StudentDTO>(st);
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
                var student = await _studentService.DeleteStudent(Id);
                return Ok(student);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("Id")]
        public async Task<IActionResult> UpdateStudent(StudentDTO studentDTO)
        {
            try
            {
                var st = _mappper.Map<Student>(studentDTO);
                var student = await _studentService.UpdateStudent(st);
                return Ok(student);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

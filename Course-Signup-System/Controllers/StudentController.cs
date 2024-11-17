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
      
        private readonly IHashPasword _hashPasword;
        public StudentController(IStudentService studentService,  IHashPasword hashPasword)
        {
            _studentService = studentService;
          
            _hashPasword = hashPasword;
        }
        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            try
            {
                var students = await _studentService.GetAllStudents();
                return Ok(students);
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
                var student = await _studentService.GetStudentById(Id);
                return Ok(student);
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
                var st = await _studentService.CreateStudent(studentDTO);
                return Ok(st);
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
                var student = await _studentService.UpdateStudent(studentDTO);
                return Ok(student);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

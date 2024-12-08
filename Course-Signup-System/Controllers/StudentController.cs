using AutoMapper;
using Course_Signup_System.DTO;
using Course_Signup_System.Entities;
using Course_Signup_System.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Course_Signup_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        [HttpGet]
        public async Task<IActionResult> GetStudents([FromQuery] int page = 1, [FromQuery] int pagesize =10)
        {
            try
            {
                var userPermissions = User.FindAll("Permission").Select(c => c.Value).ToList();
                if (userPermissions is null)
                {
                    return Forbid();
                }
                else if (userPermissions.Contains("Xem tất cả danh sách học viên"))
                {
                    var students = await _studentService.GetAllStudents(page, pagesize);
                    return Ok(students);
                }
                else
                {
                    return Forbid("khong co quyen truy cap");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetStudents(string Id)
        {
            try
            {
                var userPermissions = User.FindAll("Permission").Select(c => c.Value).ToList();
                if (userPermissions is null)
                {
                    return Forbid();
                }
                else if (userPermissions.Contains("Xem tất cả danh sách học viên"))
                {
                    var student = await _studentService.GetStudentById(Id);
                    return Ok(student);
                }
                else
                {
                    return Forbid("khong co quyen truy cap");
                }
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
                var userPermissions = User.FindAll("Permission").Select(c => c.Value).ToList();
                if (userPermissions is null)
                {
                    return Forbid();
                }
                else if (userPermissions.Contains("Thêm xóa sửa học viên"))
                {
                    var st = await _studentService.CreateStudent(studentDTO);
                    return Ok(st);
                }
                else
                {
                    return Forbid("khong co quyen truy cap");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteStudent(string Id)
        {
            try
            {
                var userPermissions = User.FindAll("Permission").Select(c => c.Value).ToList();
                if (userPermissions is null)
                {
                    return Forbid();
                }
                else if (userPermissions.Contains("Thêm xóa sửa học viên"))
                {
                    var student = await _studentService.DeleteStudent(Id);
                    return Ok(student);
                }
                else
                {
                    return Forbid("khong co quyen truy cap");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateStudent(string Id,StudentDTO studentDTO)
        {
            if(Id != studentDTO.UserId)
            {
                return BadRequest();
            }
            try
            {
                var userPermissions = User.FindAll("Permission").Select(c => c.Value).ToList();
                if (userPermissions is null)
                {
                    return Forbid();
                }
                else if (userPermissions.Contains("Thêm xóa sửa học viên"))
                {
                    var student = await _studentService.UpdateStudent(studentDTO);
                    return Ok(student);
                }
                else
                {
                    return Forbid("Khong co quyen truy cap");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet("Get-Student")]
        public async Task<IActionResult> GetStudentByEmail(string email)
        {
            try
            {
                var userPermissions = User.FindAll("Permission").Select(c => c.Value).ToList();
                if (userPermissions is null)
                {
                    return Forbid();
                }
                else if (userPermissions.Contains("Xem tất cả danh sách học viên"))
                {
                    var Student = await _studentService.GetStudentByEmail(email);
                    return Ok(Student);
                }
                else
                {
                    return Forbid("Khong co quyen truy cap");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet("{Id}/schedules")]
        public async Task<IActionResult> GetScheduleByStudent(string Id)
        {
            try
            {
                var userPermissions = User.FindAll("Permission").Select(c => c.Value).ToList();
                if (userPermissions is null)
                {
                    return Forbid();
                }
                else if (userPermissions.Contains("Xem tất cả danh sách học viên"))
                {
                    var schedule = await _studentService.GetScheduleClass(Id);
                    return Ok(schedule);
                }
                else
                {
                    return Forbid("Khong co quyen truy cap");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}

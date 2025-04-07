using Course_Signup_System.Application.DTO;
using Course_Signup_System.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace Course_Signup_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StudentClassController : ControllerBase
    {
        private readonly IStudentClassService _studentClass;
        public StudentClassController(IStudentClassService studentClass)
        {
            _studentClass = studentClass;
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateSudentClass([FromBody] StudentClassDTO studentClassDto)
        {
            try
            {
                var studentclass = await _studentClass.CreateStudentClass(studentClassDto);
                return Ok(studentclass);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet("{page}/{pagesize}")]
        public async Task<IActionResult> GetStudentClass([FromQuery] int page =1 , [FromQuery] int pagesize = 10)
        {
            try
            {
                var userPermissions = User.FindAll("Permission").Select(c => c.Value).ToList();
                if (userPermissions is null)
                {
                    return Forbid();
                }
                else if (userPermissions.Contains("Danh sách học sinh trong lớp"))
                {
                    var result = await _studentClass.GetStudentClasses(page, pagesize);
                    return Ok(result);
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
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetStudentClassById(int Id)
        {
            try
            {
                var userPermissions = User.FindAll("Permission").Select(c => c.Value).ToList();
                if (userPermissions is null)
                {
                    return Forbid();
                }
                else if (userPermissions.Contains("Danh sách học sinh trong lớp"))
                {
                    var result = await _studentClass.GetStudentClassById(Id);
                    return Ok(result);
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
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteStudentClass(int Id)
        {
            try
            {
                var userPermissions = User.FindAll("Permission").Select(c => c.Value).ToList();
                if (userPermissions is null)
                {
                    return Forbid();
                }
                else if (userPermissions.Contains("Hủy đăng kí môn học"))
                {
                    var result = await _studentClass.DeleteStudentClass(Id);
                    return Ok(result);
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
        //[HttpPut("{Id}")]
        //public async Task<IActionResult> UpdateStudentClass(int Id, StudentClassDTO studentClassDto)
        //{
        //    try
        //    {
        //        var userPermissions = User.FindAll("Permission").Select(c => c.Value).ToList();
        //        if (userPermissions is null)
        //        {
        //            return Forbid();
        //        }
        //        else if (userPermissions.Contains("Danh sách học sinh trong lớp"))
        //        {
        //            var result = await _studentClass.UpdateStudentClass(Id, studentClassDto);
        //            return Ok(result);
        //        }
        //        else
        //        {
        //            return Forbid("khong co quyen truy cap");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex);
        //    }
        //}
        [HttpGet("student-Satus")]
        public async Task<IActionResult> GetStudentByStatus(bool status)
        {
            try
            {
                var userPermissions = User.FindAll("Permission").Select(c => c.Value).ToList();
                if (userPermissions is null)
                {
                    return Forbid();
                }
                else if (userPermissions.Contains("Danh sách học sinh trong lớp"))
                {
                    var students = await _studentClass.GetStudentByStatus(status);
                    return Ok(students);
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

    }
}

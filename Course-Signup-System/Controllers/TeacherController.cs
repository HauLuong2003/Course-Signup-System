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
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _teacherService;

        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }
        [HttpGet]
        public async Task<IActionResult> GetTeachers([FromQuery] int page = 1 ,int pagesize = 10)
        //page: Số trang bạn muốn lấy (bắt đầu từ 1).
        //pageSize: Số lượng bản ghi trên mỗi trang.
        {
            try
            {
                var userPermissions = User.FindAll("Permission").Select(c => c.Value).ToList();
                if (userPermissions is null)
                {
                    return Forbid();
                }
                else if (userPermissions.Contains("Xem tất cả danh sách giảng viên"))
                {
                    var teachers = await _teacherService.GetAllTeachers(page, pagesize);

                    return Ok(teachers);
                }
                else
                {
                    return Forbid("khong co quyen");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetTeacher(string Id)
        {
            try
            {
                var userPermissions = User.FindAll("Permission").Select(c => c.Value).ToList();
                if (userPermissions is null)
                {
                    return Forbid();
                }
                else if (userPermissions.Contains("Xem tất cả danh sách giảng viên"))
                {
                    var teacher = await _teacherService.GetTeacherById(Id);

                    return Ok(teacher);
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
        [HttpPost]
        public async Task<IActionResult> CreateTeacher([FromBody]TeacherDTO teacherDTO)
        {
            try
            {
                var userPermissions = User.FindAll("Permission").Select(c => c.Value).ToList();
                if (userPermissions is null)
                {
                    return Forbid();
                }
                else if (userPermissions.Contains("Thêm xóa sửa giảng viên"))
                {
                    var st = await _teacherService.CreateTeacher(teacherDTO);
                    return Ok(st);
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
        public async Task<IActionResult> DeleteTeacher(string Id)
        {
            try
            {
                var userPermissions = User.FindAll("Permission").Select(c => c.Value).ToList();
                if (userPermissions is null)
                {
                    return Forbid();
                }
                else if (userPermissions.Contains("Thêm xóa sửa giảng viên"))
                {
                    var teacher = await _teacherService.DeleteTeacher(Id);
                    return Ok(teacher);
                }
                else
                {
                    return Forbid("khong co quyen");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateTeacher(string Id,TeacherDTO teacherDTO)
        {
            if (teacherDTO.UserId != Id)
            {
                return BadRequest("id and teacherid don't ");
            }
            try
            {
                var userPermissions = User.FindAll("Permission").Select(c => c.Value).ToList();
                if (userPermissions is null)
                {
                    return Forbid();
                }
                else if (userPermissions.Contains("Thêm xóa sửa giảng viên"))
                {
                    var teacher = await _teacherService.UpdateTeacher(teacherDTO);
                    return Ok(teacher);
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
        [HttpGet("Get-teacher")]
        public async Task<IActionResult> GetTeacherByEmail(string Email)
        {
            try
            {
                var userPermissions = User.FindAll("Permission").Select(c => c.Value).ToList();
                if (userPermissions is null)
                {
                    return Forbid();
                }
                else if (userPermissions.Contains("Xem tất cả danh sách giảng viên"))
                {
                    var teacher = await _teacherService.GetTeacherByEmail(Email);
                    return Ok(teacher);
                }
                else
                {
                    return Forbid("khong co quyen truy cap");
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet("search-teacher/{name}")]
        public async Task<IActionResult> Searchteachers(string name)
        {
            var userPermissions = User.FindAll("Permission").Select(c => c.Value).ToList();
            if (userPermissions is null)
            {
                return Forbid();
            }
            else if (userPermissions.Contains("Xem tất cả danh sách giảng viên"))
            {
                var teacher = await _teacherService.SearchTeacher(name);
                return Ok(teacher);
            }
            else
            {
                return Forbid("Khong co quyen truy cap");
            }
        }

        [HttpGet("GetSalaryTeacher")]
        public async Task<IActionResult> GetSalaryOfTeacher(string Id)
        {
            try
            {
                var userPermissions = User.FindAll("Permission").Select(c => c.Value).ToList();
                if (userPermissions is null)
                {
                    return Forbid();
                }
                else if (userPermissions.Contains("Xem tất cả danh sách giảng viên"))
                {
                    var teacher = await _teacherService.GetSalaryOfTeacher(Id);
                    return Ok(teacher);
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


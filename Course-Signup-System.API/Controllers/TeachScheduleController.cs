using Course_Signup_System.Application.DTO;
using Course_Signup_System.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Course_Signup_System.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class TeachScheduleController : ControllerBase
    {
        private readonly ITeacherScheduleService _service;
        public TeachScheduleController(ITeacherScheduleService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> CreateTeachSchedule([FromBody] TeacherScheduleDTO teacherScheduleDTO)
        {
            try
            {
                var userPermissions = User.FindAll("Permission").Select(c => c.Value).ToList();
                if (userPermissions is null)
                {
                    return Forbid();
                }
                else if (userPermissions.Contains("Thêm xóa sửa lịch giảng dạy"))
                {
                    var teachSchedule = await _service.CreateTeacherSchedule(teacherScheduleDTO);
                    return Ok(teachSchedule);
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
        [HttpGet]
        public async Task<IActionResult> GetTeachSchedule([FromQuery] int page = 1, [FromQuery] int pagesize = 10)
        {
            try
            {
                var userPermissions = User.FindAll("Permission").Select(c => c.Value).ToList();
                if (userPermissions is null)
                {
                    return Forbid();
                }
                else if (userPermissions.Contains("Xem lịch giảng dạy"))
                {
                    var teachSchedule = await _service.GetTeacherSchedule(page, pagesize);
                    return Ok(teachSchedule);
                }
                else
                {
                    return Forbid("không có quyền");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetTeachScheduleById(int Id)
        {
            try
            {
                var userPermissions = User.FindAll("Permission").Select(c => c.Value).ToList();
                if (userPermissions is null)
                {
                    return Forbid();
                }
                else if (userPermissions.Contains("Xem lịch giảng dạy"))
                {
                    var teachSchedule = await _service.GetTeacherScheduleById(Id);
                    return Ok(teachSchedule);
                }
                else
                {
                    return Forbid("không có quyền");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteTeachSchedule(int Id)
        {
            try
            {
                var userPermissions = User.FindAll("Permission").Select(c => c.Value).ToList();
                if (userPermissions is null)
                {
                    return Forbid();
                }
                else if (userPermissions.Contains("Thêm xóa sửa lịch giảng dạy"))
                {
                    var teachSchedule = await _service.DeleteTeacherSchedule(Id);
                    return Ok(teachSchedule);
                }
                else
                {
                    return Forbid("không có quyền truy cập");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateTeachSchedule(int Id,TeacherScheduleDTO teacherScheduleDTO)
        {
            try
            {
                var userPermissions = User.FindAll("Permission").Select(c => c.Value).ToList();
                if (userPermissions is null)
                {
                    return Forbid();
                }
                else if (userPermissions.Contains("Thêm xóa sửa lịch giảng dạy"))
                {
                    var teachSchedule = await _service.UpdateTeacherSchedule(Id, teacherScheduleDTO);
                    return Ok(teachSchedule);
                }
                else
                {
                    return Forbid("không có quyền");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}

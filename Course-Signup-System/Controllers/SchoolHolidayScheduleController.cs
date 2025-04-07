using Course_Signup_System.Application.DTO;
using Course_Signup_System.Domain.Entities;
using Course_Signup_System.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Course_Signup_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SchoolHolidayScheduleController : ControllerBase
    {
        private readonly ISchoolHolidayScheduleService _schoolHolidayScheduleService;
        public SchoolHolidayScheduleController(ISchoolHolidayScheduleService schoolHolidayScheduleService)
        {
            _schoolHolidayScheduleService = schoolHolidayScheduleService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateSchoolHolidaySchedule(SchoolHolidayScheduleDTO schoolHolidayScheduleDTO)
        {
            try
            {
                var userPermissions = User.FindAll("Permission").Select(c => c.Value).ToList();
                if (userPermissions is null)
                {
                    return Forbid();
                }
                else if (userPermissions.Contains("Thêm xóa sửa lịch nghỉ"))
                {
                    var sc = await _schoolHolidayScheduleService.CreateSchoolHolidaySchedule(schoolHolidayScheduleDTO);
                    return Ok(sc);
                }
                return Forbid();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> CreateSchoolHolidaySchedule(int Id)
        {
            try
            {
                var userPermissions = User.FindAll("Permission").Select(c => c.Value).ToList();
                if (userPermissions is null)
                {
                    return Forbid();
                }
                else if (userPermissions.Contains("Thêm xóa sửa lịch nghỉ"))
                {
                    var sc = await _schoolHolidayScheduleService.DeleteSchoolHolidaySchedule(Id);
                    return Ok(sc);
                }
                return Forbid();
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet]
        public async Task<IActionResult> CreateSchoolHolidaySchedule()
        {
            try
            {
                var userPermissions = User.FindAll("Permission").Select(c => c.Value).ToList();
                if (userPermissions is null)
                {
                    return Forbid();
                }
                else if (userPermissions.Contains("Danh sách lịch nghỉ"))
                {
                    var sc = await _schoolHolidayScheduleService.GetAllSchoolHolidaySchedules();
                    return Ok(sc);
                }
                return Forbid();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetSchoolHolidayScheduleById(int Id)
        {
            try
            {
                var userPermissions = User.FindAll("Permission").Select(c => c.Value).ToList();
                if (userPermissions is null)
                {
                    return Forbid();
                }
                else if (userPermissions.Contains("Danh sách lịch nghỉ"))
                {
                    var sc = await _schoolHolidayScheduleService.GetSchoolHolidaySchedule(Id);
                    return Ok(sc);
                }
                return Forbid();
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPut("{Id}")]
        public async Task<IActionResult> CreateSchoolHolidaySchedule(int Id,SchoolHolidayScheduleDTO schoolHolidayScheduleDTO)
        {
            try
            {
                var userPermissions = User.FindAll("Permission").Select(c => c.Value).ToList();
                if (userPermissions is null)
                {
                    return Forbid();
                }
                else if (userPermissions.Contains("Thêm xóa sửa lịch nghỉ"))
                {
                    var sc = await _schoolHolidayScheduleService.UpdateSchoolHolidaySchedule(schoolHolidayScheduleDTO);
                    return Ok(sc);
                }
                return Forbid();
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}

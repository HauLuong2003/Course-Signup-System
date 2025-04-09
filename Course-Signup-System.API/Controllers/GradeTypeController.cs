using Course_Signup_System.Application.DTO;
using Course_Signup_System.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Course_Signup_System.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradeTypeController : ControllerBase
    {
        private readonly IGradeTypeService _gradeTypeService;
        public GradeTypeController(IGradeTypeService gradeTypeService)
        {
            _gradeTypeService = gradeTypeService;
        }
        [Authorize(Policy = "GradeTypeAuthorize")]
        [HttpPost] 
        public async Task<IActionResult> CreateGradeType (GradeTypeDTO gradeTypeDTO)
        {
            try
            {
                var gradeType = await _gradeTypeService.CreateGradeType(gradeTypeDTO);
                return Ok(gradeType);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetGradeType([FromQuery]int page = 1, [FromQuery] int pagesize = 10)
        {
            try
            {
                var userPermissions = User.FindAll("Permission").Select(c => c.Value).ToList();

                if (userPermissions is null)
                {
                    return Forbid();
                }
                else if (userPermissions.Contains("Xem tất cả loại điểm"))
                {
                    var gradeType = await _gradeTypeService.GetGradeType(page, pagesize);
                    return Ok(gradeType);
                }
                return Forbid();
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [Authorize]
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetGradeTypeById(int Id)
        {
            try
            {
                var userPermissions = User.FindAll("Permission").Select(c => c.Value).ToList();

                if (userPermissions is null)
                {
                    return Forbid();
                }
                else if (userPermissions.Contains("Thêm xóa sửa quản lý đào tạo"))
                {
                    var gradeType = await _gradeTypeService.GetGradeTypeById(Id);
                    return Ok(gradeType);
                }
                return Forbid();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [Authorize(Policy = "GradeTypeAuthorize")]
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteGradeType(int Id)
        {
            try
            {
                var gradeType = await _gradeTypeService.DeleteGradeType(Id);
                return Ok(gradeType);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [Authorize(Policy = "GradeTypeAuthorize")]
        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateGradeType(int Id, GradeTypeDTO gradeTypeDTO)
        {
            try
            {
                var gradeType = await _gradeTypeService.UpdateGradeType(Id,gradeTypeDTO);
                return Ok(gradeType);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}

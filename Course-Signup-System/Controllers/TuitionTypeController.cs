using Course_Signup_System.DTO;
using Course_Signup_System.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Course_Signup_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TuitionTypeController : ControllerBase
    {
        private readonly ITuitionTypeService _tuitionTypeService;
        public TuitionTypeController(ITuitionTypeService tuitionTypeService)
        {
            _tuitionTypeService = tuitionTypeService;
        }
        [Authorize(Policy = "WriteTrainingManagement")]
        [HttpPost]
        public async Task<IActionResult> CreateTuitionType(TuitionTypeDTO tuitionTypeDTO)
        {
            try
            {
                var TuitionType = await _tuitionTypeService.CreateTuitionType(tuitionTypeDTO);
                return Ok(TuitionType);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [Authorize(Policy = "ReadTrainingManagement")]

        [HttpGet]
        public async Task<IActionResult> GetTuitionType()
        {
            try
            {
                var TuitionType = await _tuitionTypeService.GetTuitionType();
                return Ok(TuitionType);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [Authorize(Policy = "ReadTrainingManagement")]
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetTuitionTypeById(int Id)
        {
            try
            {
                var TuitionType = await _tuitionTypeService.GetTuitionTypeById(Id);
                return Ok(TuitionType);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [Authorize(Policy = "WriteTrainingManagement")]
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteTuitionType(int Id)
        {
            try
            {
                var TuitionType = await _tuitionTypeService.DeleteTuitionType(Id);
                return Ok(TuitionType);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [Authorize(Policy = "WriteTrainingManagement")]
        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateTuitionType(int Id,TuitionTypeDTO tuitionTypeDTO)
        {
            if(Id != tuitionTypeDTO.TuitionTypeId)
            {
                return BadRequest("Id don't Same");
            }
            try
            {
                var TuitionType = await _tuitionTypeService.UpdateTuitionType(Id,tuitionTypeDTO);
                return Ok(TuitionType);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}

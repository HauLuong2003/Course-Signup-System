using Course_Signup_System.DTO;
using Course_Signup_System.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Course_Signup_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacultyController : ControllerBase
    {
        private readonly IFacultyService _facultyService;
        public FacultyController(IFacultyService faultyService)
        {
            _facultyService = faultyService;
        }
        [Authorize(Policy = "WriteTrainingManagement")]
        [HttpPost]
        public async Task<IActionResult> CreateFaculty([FromBody]FacultyDTO facultyDTO)
        {
            try
            {
                var faculty = await _facultyService.CreateFaculty(facultyDTO);
                return Ok(faculty);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [Authorize(Policy = "ReadTrainingManagement")]
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetFacultybyId(string Id)
        {
            try
            {
                var faculty = await _facultyService.GetFacultyById(Id);
                return Ok(faculty);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [Authorize(Policy = "WriteTrainingManagement")]
        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateFaculty(string Id,FacultyDTO facultyDTO)
        {
            if (Id != facultyDTO.FacultyId)
            {
                return BadRequest("id and facultyId don't");
            }
            try
            {
                var faculty = await _facultyService.UpdateFaculty(facultyDTO);
                return Ok(faculty);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [Authorize(Policy = "ReadTrainingManagement")]
        [HttpGet]
        public async Task<IActionResult> GetAllFaculty([FromQuery] int page = 1, [FromQuery] int pagesize =10)
        {
            try
            {
                var faculty = await _facultyService.GetAllFaculty(page, pagesize);
                return Ok(faculty);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Policy = "WriteTrainingManagement")]
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteFaculty(string Id)
        {
            var faculty = await _facultyService.DeleteFaculty(Id);
            return Ok(faculty);
        }
    }
}

using Course_Signup_System.DTO;
using Course_Signup_System.Services;
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
        [HttpGet("{page}/{pagesize}")]
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
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteFaculty(string Id)
        {
            var faculty = await _facultyService.DeleteFaculty(Id);
            return Ok(faculty);
        }
    }
}

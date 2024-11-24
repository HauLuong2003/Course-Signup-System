using Course_Signup_System.DTO;
using Course_Signup_System.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Course_Signup_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            var studentclass = await _studentClass.CreateStudentClass(studentClassDto);
            return Ok(studentclass);
        }
        [HttpGet("{page}/{pagesize}")]
        public async Task<IActionResult> GetStudentClass([FromQuery] int page =1 , [FromQuery] int pagesize = 10)
        {
            var result = await _studentClass.GetStudentClasses(page, pagesize);
            return Ok(result);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetStudentClassById(int Id)
        {
            var result = await _studentClass.GetStudentClassById(Id);
            return Ok(result);
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteStudentClass(int Id)
        {
            var result = await _studentClass.DeleteStudentClass(Id);
            return Ok(result);
        }
        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateStudentClass (int Id,StudentClassDTO studentClassDto)
        {
            var result = await _studentClass.UpdateStudentClass(Id, studentClassDto);
            return Ok(result);
        }
    }
}

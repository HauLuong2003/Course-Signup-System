using Course_Signup_System.DTO;
using Course_Signup_System.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Course_Signup_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassOfController : ControllerBase
    {
        private readonly IClassOfService _classOfService;
        public ClassOfController (IClassOfService classOfService)
        {
            _classOfService = classOfService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateClassof([FromBody] ClassOfDTO classOfDTO)
        {
            try
            {
                var classof = await _classOfService.CreateClassOf(classOfDTO);
                return Ok(classof);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetClassof([FromQuery]int page = 1, [FromQuery] int pagesize = 10)
        {
            try
            {
                var classofs = await _classOfService.GetAllClassOf(page, pagesize);
                return Ok(classofs);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetClassof(string Id)
        {
            try
            {
                var classof = await _classOfService.GetClassOfById(Id);
                return Ok(classof);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteClassOf(string Id)
        {
            try
            {
                var classof = await _classOfService.DeleteClassOf(Id);
                return Ok(classof);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPut("{Id}")]
        public async Task<IActionResult> DeleteClassOf(string Id,ClassOfDTO classOfDTO)
        {
            if(classOfDTO.ClassOfId != Id)
            {
                return BadRequest("Id and classofId incorrect");
            }
            try
            {
                var classof = await _classOfService.UpdateClassOf(classOfDTO);
                return Ok(classof);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}

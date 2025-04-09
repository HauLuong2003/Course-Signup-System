using Course_Signup_System.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Course_Signup_System.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileStorageController : ControllerBase
    {
        private readonly IFileStorageService _fileStorageService;
        private readonly IStudentService _studentService;
        public FileStorageController(IFileStorageService fileStorageService, IStudentService studentService)
        {
            _fileStorageService = fileStorageService;   
            _studentService = studentService;
        }
        [HttpPost]
        public async Task<IActionResult> FileStorage(IFormFile file)
        {
            if (file == null ||  file.Length == 0)
            {
                 return BadRequest("No file uploaded.");
            }
            try
            {
                using (var memory = new MemoryStream())
                {
                    await file.CopyToAsync(memory);
                    var filedata = memory.ToArray();
                    var image = await _fileStorageService.UploadFile(filedata, file.FileName, file.ContentType);
                    return Ok(image);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [Authorize]
        [HttpPost("Invoice")]
        public async Task<IActionResult> GeneratePDF(string Id)
        {
            var userPermissions = User.FindAll("Permission").Select(c => c.Value).ToList();
            if (userPermissions is null)
            {
                return Forbid();
            }
            else if (userPermissions.Contains("Xuất báo cáo"))
            {
                var pdf = await _fileStorageService.GeneratePDF(Id);
                var student = await _studentService.GetStudentById(Id);
                var filename = student.LastName + student.FirstName + ".pdf";
                return File(pdf, "application/pdf", filename);
            }
            return Forbid();
        }
        [Authorize]
        [HttpPost("Report")]
        public async Task<IActionResult> GetReport(DateTime dateTime)
        {
            var userPermissions = User.FindAll("Permission").Select(c => c.Value).ToList();
            if (userPermissions is null)
            {
                return Forbid();
            }
            else if (userPermissions.Contains("Xuất báo cáo"))
            {
                var report = await _fileStorageService.GenerateRevenue(dateTime);
                return File(report, "application/pdf", dateTime + ".pdf");
            }
            return Forbid();
        }
    }
}

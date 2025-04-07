using Course_Signup_System.Application.DTO;
using Course_Signup_System.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Course_Signup_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class PayTuitionController : ControllerBase
    {
        private readonly IPayTuitionService _payTuitionService;
        public PayTuitionController(IPayTuitionService paymentService)
        {
            _payTuitionService = paymentService;
        }
        [HttpPost]
        public async Task<IActionResult> CreatePaytuition(PaytuitionDTO paytuitionDTO)
        {
            try
            {
                var paytuition = await _payTuitionService.PayTuition(paytuitionDTO);
                return Ok(paytuition);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetPaytuition()
        {
            try
            {
                var paytuition = await _payTuitionService.GetPayTuition();
                return Ok(paytuition);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}

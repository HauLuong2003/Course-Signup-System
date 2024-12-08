using Course_Signup_System.DTO.Request;
using Course_Signup_System.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Course_Signup_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] Login login)
        {
            try
            {
                var result = await _authService.Login(login);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPost("ForgetPassword")]
        public async Task<IActionResult> ForgetPassword(ForgetPassword forgetPassword)
        {
            try
            {

                var result = await _authService.ForgetPassword(forgetPassword);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [Authorize(Policy = "VerificationToken")]
        [HttpPost("VerificationToken")]
        public async Task<IActionResult> VerificationToken(VerificationToken VerificationToken)
        {
            try
            {
                var email = User.FindFirstValue(ClaimTypes.Email);
                VerificationToken.Email = email;
                var result = await _authService.VerificationToken(VerificationToken);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [Authorize(Policy ="VerificationToken")]
        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword(ResetPassword ResetPassword)
        {
            try
            {
                var email = User.FindFirstValue(ClaimTypes.Email);
                ResetPassword.Email = email;
                var result = await _authService.ResetPassword(ResetPassword);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}

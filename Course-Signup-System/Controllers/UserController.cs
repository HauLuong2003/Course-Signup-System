using AutoMapper;
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
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
       
        public UserController(IUserService userService)
        {
            _userService = userService;  
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserDTO userDto)
        {
            try
            {
                var userPermissions = User.FindAll("Permission").Select(c => c.Value).ToList();
                if (userPermissions is null)
                {
                    return Forbid();
                }
                else if (userPermissions.Contains("Thêm xóa sửa người dùng"))
                {
                    var user = await _userService.CreateUser(userDto);
                    return Ok(user);
                }
                else
                {
                    return Forbid();

                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers([FromQuery] int page = 1, [FromQuery] int pagesize =10)
        {
            try
            {
                var userPermissions = User.FindAll("Permission").Select(c => c.Value).ToList();
                if (userPermissions is null)
                {
                    return Forbid();
                }
                else if (userPermissions.Contains("Xem danh sách người dùng"))
                {
                    var users = await _userService.GetUser(page, pagesize);
                    return Ok(users);
                }
                else
                {
                    return Forbid();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetUserById(string Id)
        {
            try
            {
                var user = await _userService.GetUserById(Id);
               
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); 
            }
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteUser(string Id)
        {
            try
            {
                var userPermissions = User.FindAll("Permission").Select(c => c.Value).ToList();
                if (userPermissions is null)
                {
                    return Forbid();
                }
                else if (userPermissions.Contains("Thêm xóa sửa người dùng"))
                {
                    var users = await _userService.DeleteUser(Id);
                    return Ok(users);
                }
                else
                {
                    return Forbid();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateUser(string Id,UserDTO userDto)
        {
            if(Id != userDto.UserId)
            {
                return BadRequest("id and userid don't");
            }
            try
            {
                var userPermissions = User.FindAll("Permission").Select(c => c.Value).ToList();
                if (userPermissions is null)
                {
                    return Forbid();
                }
                else if (userPermissions.Contains("Thêm xóa sửa người dùng"))
                {
                    var user = await _userService.UpdateUser(userDto);
                    return Ok(user);
                }
                else
                {
                    return Forbid("không có quyền truy cập");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpGet("Get-UserEmail")]
        public async Task<IActionResult> GetUserbyrole(string email)
        {
            var userPermissions = User.FindAll("Permission").Select(c => c.Value).ToList();
            if (userPermissions is null)
            {
                return Forbid();
            }
            else if (userPermissions.Contains("Xem danh sách người dùng"))
            {
                var result = await _userService.GetUserByEmail(email);
                return Ok(result);
            }
            else
            {
                return Forbid("không có quyền truy cập");
            }
        }
    }
}

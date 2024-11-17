using AutoMapper;
using Course_Signup_System.DTO;
using Course_Signup_System.Entities;
using Course_Signup_System.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Course_Signup_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IHashPasword _hashPasword;
        public UserController(IUserService userService, IMapper mapper, IHashPasword hashPasword)
        {
            _userService = userService;
            _mapper = mapper;
            _hashPasword = hashPasword;
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserDTO userDto)
        {
            try
            {

                _hashPasword.CreateHashPassword(userDto.Password, out string HashPassword, out string PasswordSalt);
                var user = _mapper.Map<User>(userDto);
                user.PasswordHash = HashPassword;
                user.PasswordSalt = PasswordSalt;
                var u = await _userService.CreateUser(user);
                var Usermapper = _mapper.Map<UserDTO>(u);
                return Ok(Usermapper);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var u = await _userService.GetUser();
                var users = _mapper.Map<List<UserDTO>>(u);
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("Id")]
        public async Task<IActionResult> GetUserById(string userId)
        {
            try
            {
                var u = await _userService.GetUserById(userId);
                var user = _mapper.Map<UserDTO>(u);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); 
            }
        }
        [HttpDelete("Id")]
        public async Task<IActionResult> DeleteUser(string Id)
        {
            try
            {
                var users = await _userService.DeleteUser(Id);
              
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateUser(UserDTO userDto)
        {
            try
            {
                var user = _mapper.Map<User>(userDto);
                var users = await _userService.UpdateUser(user);            
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}

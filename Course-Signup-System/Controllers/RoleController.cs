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
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;

        public RoleController(IRoleService roleService, IMapper mapper)
        {
            _roleService = roleService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole ([FromBody] RoleDTO roleDTO)
        {
            try
            {
                var role = _mapper.Map<Role>(roleDTO);
                var r = await _roleService.CreateRole(role);
                var roleMapper = _mapper.Map<RoleDTO>(r);
                return Ok(roleMapper);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetRoles()
        {
            try
            {
                var roles = await _roleService.GetRoles();
                var RoleMapper = _mapper.Map<List<RoleDTO>>(roles);
                return Ok(RoleMapper);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetRoleById (int Id)
        {
            try
            {
                var role = await _roleService.GetRoleById(Id);
                var roleid = _mapper.Map<RoleDTO>(role);
                return Ok(roleid);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("Id")]
        public async Task<IActionResult> DeleteRole(int Id)
        {
            try
            {
                var role = await _roleService.DeleteRole(Id);
                return Ok(role);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateRole(RoleDTO roleDTO)
        {
            try{
                var role = _mapper.Map<Role>(roleDTO);
                var r = await _roleService.UpdateRole(role);
                var roleMapper = _mapper.Map<RoleDTO>(r);
                return Ok(roleMapper);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

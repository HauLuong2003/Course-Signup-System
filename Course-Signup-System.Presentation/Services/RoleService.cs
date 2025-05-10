using Course_Signup_System.Application.DTO;
using Course_Signup_System.Application.DTO.Reponse;
using Course_Signup_System.Application.Services;

namespace Course_Signup_System.Presentation.Services
{
    public class RoleService : BaseService, IRoleService
    {
        private string BaseUrl = "api/Role";
        public RoleService(HttpClient httpClient) : base(httpClient)
        {
        }

        public Task<RoleDTO> CreateRole(RoleDTO roleDTO)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse> DeleteRole(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<RoleDTO> GetRoleById(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<RoleDTO>> GetRoles()
        {
           var response = await _httpClient.GetAsync($"{BaseUrl}");
           var result = await response.Content.ReadAsStringAsync();
           return DeserializeJsonString<List<RoleDTO>>(result);
        }

        public Task<ServiceResponse> UpdateRole(RoleDTO role)
        {
            throw new NotImplementedException();
        }
    }
}

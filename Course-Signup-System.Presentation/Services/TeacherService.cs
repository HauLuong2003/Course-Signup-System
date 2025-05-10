using Course_Signup_System.Application.DTO;
using Course_Signup_System.Application.DTO.Reponse;
using Course_Signup_System.Application.Services;

namespace Course_Signup_System.Presentation.Services
{
    public class TeacherService : BaseService, ITeacherService
    {
        private string BaseUrl = "api/Teacher";
        public TeacherService(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<ServiceResponse> CreateTeacher(TeacherDTO teacher)
        {
            var response = await _httpClient.PostAsync($"{BaseUrl}",GenerateStringContent(SerializeObj(teacher)));
            if(!response.IsSuccessStatusCode)
            {
                return new ServiceResponse(false, "Create don't success");
            }
            var result =await response.Content.ReadAsStringAsync();
            return DeserializeJsonString<ServiceResponse>(result);
        }

        public async Task<ServiceResponse> DeleteTeacher(string Id)
        {
            var response = await _httpClient.DeleteAsync($"{BaseUrl}/{Id}");
            if(!response.IsSuccessStatusCode)
            {
                return new ServiceResponse(false,"Delete success");

            }
            var result = await response.Content.ReadAsStringAsync();
            return DeserializeJsonString<ServiceResponse>(result);
        }

        public async Task<PageResult<TeacherDTO>> GetAllTeachers(int page, int pagesize)
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}/GetTeacher?page={page}&pageSize={pagesize}");
            var result = await response.Content.ReadAsStringAsync();
            return DeserializeJsonString<PageResult<TeacherDTO>>(result);
        }

        public async Task<TeacherSalary> GetSalaryOfTeacher(string TeacherId)
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}/GetSalaryTeacher?Id={TeacherId}");
            var result = await response.Content.ReadAsStringAsync();
            return DeserializeJsonString<TeacherSalary>(result);
        }

        public async Task<TeacherDTO> GetTeacherByEmail(string Email)
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}/GetTeacherByEmail?Email={Email}");
            var result = await response.Content.ReadAsStringAsync();
            return DeserializeJsonString<TeacherDTO>(result);
        }

        public async Task<TeacherDTO> GetTeacherById(string id)
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}/{id}");
            var result = await response.Content.ReadAsStringAsync();
            return DeserializeJsonString<TeacherDTO>(result);
        }

        public async Task<List<TeacherDTO>> SearchTeacher(string Name)
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}/search-teacher/{Name}");
            var result = await response.Content.ReadAsStringAsync();
            return DeserializeJsonString<List<TeacherDTO>>(result);
        }

        public async Task<ServiceResponse> UpdateTeacher(TeacherDTO teacher)
        {
            var response = await _httpClient.PutAsync($"{BaseUrl}/{teacher.UserId}",GenerateStringContent(SerializeObj(teacher)));
            if (!response.IsSuccessStatusCode)
            {
                return new ServiceResponse(false, "update don't success");
            }
            var result = await response.Content.ReadAsStringAsync();
            return DeserializeJsonString<ServiceResponse>(result);
        }
    }
}

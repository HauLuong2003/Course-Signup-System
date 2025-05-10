using Course_Signup_System.Application.DTO;
using Course_Signup_System.Application.DTO.Reponse;
using Course_Signup_System.Application.Services;

namespace Course_Signup_System.Presentation.Services
{
    public class StudentService : BaseService,IStudentService
    {
        //private readonly HttpClient _httpClient;
        private string BaseUrl = "api/Student";
        public StudentService(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<ServiceResponse> CreateStudent(StudentDTO student)
        {
            var newstudent = await _httpClient.PostAsync($"{BaseUrl}/Add-Student",GenerateStringContent(SerializeObj(student)));
            if(!newstudent.IsSuccessStatusCode)
            {
                return new ServiceResponse(false, "Create don't success");
            }
            var result = await newstudent.Content.ReadAsStringAsync();
            return DeserializeJsonString<ServiceResponse>(result);
        }

        public async Task<ServiceResponse> DeleteStudent(string Id)
        {
            var reponse = await _httpClient.DeleteAsync($"{BaseUrl}/Delete-Student/{Id}");
            var result = await reponse.Content.ReadAsStringAsync();

            return DeserializeJsonString<ServiceResponse>(result);
        }

        public async Task<PageResult<StudentDTO>> GetAllStudents(int page, int pagesize)
        {
            var st = await _httpClient.GetAsync($"{BaseUrl}/GetStudent?page={page}&pageSize={pagesize}");
            var result = await st.Content.ReadAsStringAsync();
            return DeserializeJsonString<PageResult<StudentDTO>>(result);
        }

        public async Task<List<TeacherScheduleDTO>> GetScheduleClass(string StudentId)
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}/{StudentId}/schedules");
            var result = await response.Content.ReadAsStringAsync();
            return DeserializeJsonString<List<TeacherScheduleDTO>>(result);
        }

        public async Task<List<StudentDTO>> GetStudentByEmail(string Email)
        {
          var response = await _httpClient.GetAsync($"{BaseUrl}/GetStudentByEmail?email={Email}");
            var result = await response.Content.ReadAsStringAsync();
            return DeserializeJsonString<List<StudentDTO>>(result);

        }

        public async Task<StudentDTO> GetStudentById(string id)
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}/Get-Student/{id}");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return DeserializeJsonString<StudentDTO>(result);
            }
            return null!;

        }

        public async Task<List<StudentDTO>> SearchStudent(string Name)
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}/SearchStudent?name={Name}");
            var result = await response.Content.ReadAsStringAsync();
            return DeserializeJsonString<List<StudentDTO>>(result);
        }

        public async Task<ServiceResponse> UpdateStudent(StudentDTO student)
        {
            var response = await _httpClient.PutAsync($"{BaseUrl}/Update-Student/{student.UserId}",GenerateStringContent(SerializeObj(student)));
            var result = await response.Content.ReadAsStringAsync();
            return DeserializeJsonString<ServiceResponse>(result);
            
        }
    }
}

using Course_Signup_System.Application.DTO;
using Course_Signup_System.Application.DTO.Reponse;
using Course_Signup_System.Application.Services;

namespace Course_Signup_System.Presentation.Services
{
    public class SubjectService : BaseService, ISubjectService
    {
        private string BaseUrl = "api/Subject";
        public SubjectService(HttpClient httpClient) : base(httpClient)
        {
        }

        public Task<SubjectDTO> CreateSubject(SubjectDTO SubjectDTO)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse> DeleteSubject(string SubjectId)
        {
            throw new NotImplementedException();
        }

        public async Task<PageResult<SubjectDTO>> GetAllSubject(int page, int pagesize)
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}?page={page}&pagesize={pagesize}");
            var result = await response.Content.ReadAsStringAsync();
            return DeserializeJsonString<PageResult<SubjectDTO>>(result);
        }

        public Task<SubjectDTO> GetSubjectById(string SubjectId)
        {
            throw new NotImplementedException();
        }

        public Task<List<SubjectDTO>> SearchSubject(int DepartmentId, string FacultyId)
        {
            throw new NotImplementedException();
        }

        public Task<List<SubjectDTO>> SearchSubjectByName(string SubjectName)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse> UpdateSubject(SubjectDTO SubjectDTO)
        {
            throw new NotImplementedException();
        }
    }
}

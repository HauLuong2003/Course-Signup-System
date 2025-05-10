using Course_Signup_System.Application.Services;
using Microsoft.IdentityModel.Tokens;

namespace Course_Signup_System.Presentation.Services
{
    public class FileStorageService : BaseService,IFileStorageService
    {
        private string BaseUrl = "api/FileStorage";
        public FileStorageService(HttpClient httpClient) : base(httpClient)
        {
        }

        public Task<byte[]> GeneratePDF(string studentId)
        {
            throw new NotImplementedException();
        }

        public Task<byte[]> GenerateRevenue(DateTime dateTime)
        {
            throw new NotImplementedException();
        }

        public async Task<string> UploadFile(byte[] fileData, string fileName, string contentType)
        {
            var content = new MultipartFormDataContent();
            var byteArrayContent = new ByteArrayContent(fileData);
            byteArrayContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(contentType);
            content.Add(byteArrayContent, "file", fileName);
            var response = await _httpClient.PostAsync($"{BaseUrl}/UploadFile", content);
            if(response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return result;
                
            }
            return null!;
        }
    }
}

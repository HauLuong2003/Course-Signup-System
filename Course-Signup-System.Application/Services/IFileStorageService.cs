using Course_Signup_System.Application.DTO.Reponse;

namespace Course_Signup_System.Application.Services
{
    public interface IFileStorageService
    {
        Task<string> UploadFile(byte[] fileData, string fileName, string contentType);
        Task<byte[]> GeneratePDF(string studentId);
        Task<byte[]> GenerateRevenue(DateTime dateTime);
    }
}

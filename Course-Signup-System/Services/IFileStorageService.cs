using Course_Signup_System.DTO.Reponse;
using Microsoft.AspNetCore.Mvc;

namespace Course_Signup_System.Services
{
    public interface IFileStorageService
    {
        Task<string> UploadFile(byte[] fileData, string fileName, string contentType);
        Task<byte[]> GeneratePDF(string studentId);
        Task<byte[]> GenerateRevenue(DateTime dateTime);
    }
}

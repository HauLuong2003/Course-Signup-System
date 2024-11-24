namespace Course_Signup_System.Services
{
    public interface IFileStorageService
    {
        Task<string> UploadFile(byte[] fileData, string fileName, string contentType);

    }
}

using Course_Signup_System.DTO.Reponse;
using Course_Signup_System.DTO;

namespace Course_Signup_System.Services
{
    public interface IDepartmentService
    {
        Task<DepartmentDTO> CreateDepartment(DepartmentDTO DepartmentDTO);
        Task<List<DepartmentDTO>> GetAllDepartment();
        Task<ServiceResponse> DeleteDepartment(int Id);
        Task<DepartmentDTO> GetDepartmentById(int  Id);
        Task<ServiceResponse> UpdateDepartment(DepartmentDTO DepartmentDTO);
    }
}

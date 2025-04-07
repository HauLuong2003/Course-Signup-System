using Course_Signup_System.Application.DTO.Reponse;
using Course_Signup_System.Application.DTO;

namespace Course_Signup_System.Application.Services
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

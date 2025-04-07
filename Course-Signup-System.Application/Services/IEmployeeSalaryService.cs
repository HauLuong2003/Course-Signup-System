using Course_Signup_System.Application.DTO;
using Course_Signup_System.Application.DTO.Reponse;

namespace Course_Signup_System.Application.Services
{
    public interface IEmployeeSalaryService
    {
        Task<EmployeeSalaryDTO> CreateSalary (EmployeeSalaryDTO employeeSalaryDTO);
        Task<ServiceResponse> UpdateSalary(EmployeeSalaryDTO employeeSalaryDTO);
        Task<PageResult<EmployeeSalaryDTO>> GetAllSalary(int page, int pagesize);
        Task<EmployeeSalaryDTO> GetSalaryById(int Id);
        Task<ServiceResponse> DeleteSalary(int Id);

    }
}

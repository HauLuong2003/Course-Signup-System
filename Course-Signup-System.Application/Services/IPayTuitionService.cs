using Course_Signup_System.Application.DTO;

namespace Course_Signup_System.Application.Services
{
    public interface IPayTuitionService
    {
        Task<List<PaytuitionDTO>> GetPayTuition();
        Task<PaytuitionDTO> PayTuition(PaytuitionDTO paytuitionDTO);
    }
}

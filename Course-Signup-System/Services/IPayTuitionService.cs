using Course_Signup_System.DTO;
using Course_Signup_System.Entities;

namespace Course_Signup_System.Services
{
    public interface IPayTuitionService
    {
        Task<List<PaytuitionDTO>> GetPayTuition();
        Task<PaytuitionDTO> PayTuition(PaytuitionDTO paytuitionDTO);
    }
}

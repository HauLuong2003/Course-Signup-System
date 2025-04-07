using AutoMapper;
using Course_Signup_System.Infrastructure.Data;
using Course_Signup_System.Application.DTO;
using Course_Signup_System.Domain.Entities;
using Course_Signup_System.Application.Services;
using Microsoft.EntityFrameworkCore;

namespace Course_Signup_System.Infrastructure.Repositories
{
    public class PayTuitionRepository : IPayTuitionService
    {
        private readonly IMapper _mapper;
        private readonly CourseSystemDB _courseSystemDB;
        public PayTuitionRepository(IMapper mapper, CourseSystemDB courseSystemDB)
        {
            _mapper = mapper;
            _courseSystemDB = courseSystemDB;
        }

        public async Task<List<PaytuitionDTO>> GetPayTuition()
        {
            var paytuition = await _courseSystemDB.PayTuitions.Include(st => st.StudentClass.Student)
                                                              .Include(st=> st.StudentClass.Class)
                                                              .ToListAsync();
            return _mapper.Map<List<PaytuitionDTO>>(paytuition);
        }

        public async Task<PaytuitionDTO> PayTuition(PaytuitionDTO paytuitionDTO)
        {
           var paytuition  = _mapper.Map<PayTuition>(paytuitionDTO);
            paytuition.CreateAt = DateTime.Now;
           _courseSystemDB.PayTuitions.Add(paytuition);
            await _courseSystemDB.SaveChangesAsync();
            var studentClass = await _courseSystemDB.StudentClasses.FindAsync(paytuitionDTO.StudentClassId);
            studentClass!.Status = true;
            await _courseSystemDB.SaveChangesAsync();
            return _mapper.Map<PaytuitionDTO>(paytuition);
        }
    }
}

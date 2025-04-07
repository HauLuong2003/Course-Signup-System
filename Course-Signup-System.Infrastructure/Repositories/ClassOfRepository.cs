using Course_Signup_System.Infrastructure.Data;
using Course_Signup_System.Application.DTO.Reponse;
using Course_Signup_System.Application.DTO;
using Course_Signup_System.Domain.Entities;
using Course_Signup_System.Application.Services;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace Course_Signup_System.Infrastructure.Repositories
{
    public class ClassOfRepository : IClassOfService
    {
        private readonly IMapper _mapper;
        private readonly CourseSystemDB _courseSystemDB;
        public ClassOfRepository( IMapper mapper,CourseSystemDB courseSystemDB)
        {
            _mapper = mapper;
            _courseSystemDB = courseSystemDB;
        }
        public async Task<ClassOfDTO> CreateClassOf(ClassOfDTO classDTO)
        {
            var classof = _mapper.Map<ClassOf>(classDTO);

            _courseSystemDB.ClassOf.Add(classof);
            await _courseSystemDB.SaveChangesAsync();
            return _mapper.Map<ClassOfDTO>(classof);
        }

        public async Task<ServiceResponse> DeleteClassOf(string ClassOfId)
        {
            var classof = await _courseSystemDB.ClassOf.FindAsync(ClassOfId);
            if (classof == null)
            {
                return new ServiceResponse(false, "class of is null");
            }
            _courseSystemDB.ClassOf.Remove(classof);
            await _courseSystemDB.SaveChangesAsync();
            return new ServiceResponse(true, "delete success");
        }

        public async Task<PageResult<ClassOfDTO>> GetAllClassOf(int page, int pagesize)
        {
            var query = _courseSystemDB.ClassOf.AsQueryable();
            var count = await query.CountAsync();

            var classof = await query.Skip((page - 1) * pagesize)
                                        .Take(pagesize).ToListAsync();
            var classofDTO = _mapper.Map<List<ClassOfDTO>>(classof);
            return new PageResult<ClassOfDTO>
            {
                Page = page,
                PageSize = pagesize,
                TotalRecoreds = count,
                TotalPages = (int)Math.Ceiling(count / (double)pagesize),
                Data = classofDTO
            };
        }

        public async Task<ClassOfDTO> GetClassOfById(string ClassId)
        {
            var classof = await _courseSystemDB.ClassOf.FindAsync(ClassId);
            if (classof == null)
            {
                throw new ArgumentException("class of is null");
            }
            return _mapper.Map<ClassOfDTO>(classof);
        }

        public async Task<ServiceResponse> UpdateClassOf(ClassOfDTO ClassOfDTO)
        {
            var classof = await _courseSystemDB.ClassOf.FindAsync(ClassOfDTO.ClassOfId);
            if (classof == null)
            {
                return new ServiceResponse(false, "update don't success");
            }
            var ClassOf = _mapper.Map<ClassOf>(ClassOfDTO);
            classof.ClassOfName = ClassOf.ClassOfName;
            await _courseSystemDB.SaveChangesAsync();
            return new ServiceResponse(true, "update success");
        }
    }
}

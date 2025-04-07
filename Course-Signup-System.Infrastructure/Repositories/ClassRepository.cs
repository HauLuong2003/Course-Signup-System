using Course_Signup_System.Infrastructure.Data;
using Course_Signup_System.Application.DTO.Reponse;
using Course_Signup_System.Application.DTO;
using Course_Signup_System.Domain.Entities;
using Course_Signup_System.Application.Services;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace Course_Signup_System.Infrastructure.Repositories
{
    public class ClassRepository : IClassService
    {
        private readonly IMapper _mapper;
        private readonly CourseSystemDB _courseSystemDB;
        public ClassRepository(IMapper mapper,CourseSystemDB courseSystemDB)
        {
            _mapper = mapper;
            _courseSystemDB = courseSystemDB;
        }

        public async Task<ClassDTO> CreateClass(ClassDTO classDTO)
        {
            var Class = _mapper.Map<Class>(classDTO);
            await _courseSystemDB.Classes.AddAsync(Class);
            await _courseSystemDB.SaveChangesAsync();
            return _mapper.Map<ClassDTO>(Class);
        }

        public async Task<ServiceResponse> DeleteClass(string ClassId)
        {
            var Class = await _courseSystemDB.Classes.FindAsync(ClassId);
            if (Class == null)
            {
                return new ServiceResponse(false, "delete don't success");
            }
            _courseSystemDB.Classes.Remove(Class);
            await _courseSystemDB.SaveChangesAsync();
            return new ServiceResponse(true, "delete success");
        }

        public async Task<PageResult<ClassDTO>> GetAllClass(int page, int pagesize)
        {
            var query = _courseSystemDB.Classes.AsQueryable();
            var count = await query.CountAsync();
            var Classes = await _courseSystemDB.Classes
                                        .Skip((page - 1) * pagesize)
                                        .Take(pagesize)
                                        .ToListAsync();
            var classdto = _mapper.Map<List<ClassDTO>>(Classes);
            return new PageResult<ClassDTO>
            {
                Page = page,
                PageSize = pagesize,
                TotalPages = (int)Math.Ceiling(count / (double)pagesize),
                TotalRecoreds = count,
                Data = classdto

            };
        }

        public async Task<ClassDTO> GetClassById(string ClassId)
        {
            var Class = await _courseSystemDB.Classes.FindAsync(ClassId);
            if (Class == null)
            {
                throw new ArgumentNullException("class is null");
            }
            return _mapper.Map<ClassDTO>(Class);
        }

        public async Task<List<ClassDTO>> SearchClass(string name)
        {
            var Class = await _courseSystemDB.Classes.Where(c => c.ClassName.Contains(name)).ToListAsync();
            if (Class == null)
            {
                throw new ArgumentNullException("class is null");
            }
            return _mapper.Map<List<ClassDTO>>(Class);
        }

        public async Task<ServiceResponse> UpdateClass(ClassDTO ClassDTO)
        {
            var Class = await _courseSystemDB.Classes.FindAsync(ClassDTO.ClassId);
            if (Class == null)
            {
                return new ServiceResponse(false, "class is null");
            }
            var cl = _mapper.Map<Class>(ClassDTO);
            Class.ClassName = cl.ClassName;
            Class.Status = cl.Status;
            Class.Tuition = cl.Tuition;
            Class.NumberStudent = cl.NumberStudent;
            Class.MaxNumberStudent = cl.MaxNumberStudent;
            Class.Avatar = cl.Avatar;
            Class.Description = cl.Description;
            Class.StudentClasses = cl.StudentClasses;
            Class.SubjectClasses = cl.SubjectClasses;
            return new ServiceResponse(true, "update success");
        }
    }
}

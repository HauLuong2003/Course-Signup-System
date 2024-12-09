using AutoMapper;
using Course_Signup_System.Data;
using Course_Signup_System.DTO;
using Course_Signup_System.DTO.Reponse;
using Course_Signup_System.Entities;
using Course_Signup_System.Services;
using Microsoft.EntityFrameworkCore;

namespace Course_Signup_System.Repositories
{
    public class GradeColumnRepository : IGradeColumnService
    {
        private readonly IMapper _mapper;
        private readonly CourseSystemDB _courseSystemDB;
        public GradeColumnRepository(IMapper mapper, CourseSystemDB courseSystemDB)
        {
            _mapper = mapper;
            _courseSystemDB = courseSystemDB;
        }

        public async Task<GradeColumnDTO> CreateGrade(GradeColumnDTO GradeColumnDTO)
        {
            
            var grade = _mapper.Map<GradeColumn>(GradeColumnDTO); 
            var subjectGrade = await _courseSystemDB.Grades.Include(s => s.Subject)
                                                            .ThenInclude(g =>g.SubjectGradeTypes).FirstOrDefaultAsync(g => g.GradeId == GradeColumnDTO.GradeId);
            var gradeColumn = await _courseSystemDB.GradeColumns.Where(f => f.GradeId == GradeColumnDTO.GradeId).CountAsync();

            if (subjectGrade == null)
            {
                throw new Exception("subjectGrade is null");
            }
            else if (subjectGrade.Subject.SubjectGradeTypes.Max(s=>s.GradeColumn) > gradeColumn || subjectGrade.Subject.SubjectGradeTypes.Max(s => s.MandatoryColumnGrade) > gradeColumn)
            {
                _courseSystemDB.GradeColumns.Add(grade);
                await _courseSystemDB.SaveChangesAsync();
                return _mapper.Map<GradeColumnDTO>(grade);

            }
            else 
            {
                throw new Exception("the spot has darkened");
            }
        }

        public async Task<ServiceResponse> DeleteGradeType(int GradeColumnId)
        {
            var grade = await _courseSystemDB.GradeColumns.FindAsync(GradeColumnId);
            if(grade == null)
            {
                return new ServiceResponse(false, "grade column is null");
            }
            _courseSystemDB.GradeColumns.Remove(grade);
            await _courseSystemDB.SaveChangesAsync();
            return new ServiceResponse(true, "delete success");
        }

        public async Task<List<GradeColumnDTO>> GetGrade()
        {
            var grade = await _courseSystemDB.GradeColumns.ToListAsync();
            return _mapper.Map<List<GradeColumnDTO>>(grade);
        }

        public async Task<GradeColumnDTO> GetGradeById(int GradeColumnId)
        {
            var grade = await _courseSystemDB.GradeColumns.FindAsync(GradeColumnId);
            if (grade == null)
            {
                throw new ArgumentNullException( "grade column is null");
            };
            return _mapper.Map<GradeColumnDTO>(grade);
        }

        public async Task<ServiceResponse> UpdateGrade(int Id, GradeColumnDTO GradeColumnDTO)
        {
            var grade = await _courseSystemDB.GradeColumns.FindAsync(Id);
            if (grade == null)
            {
                return new ServiceResponse(false, "grade column is null");
            }
            grade.Score = GradeColumnDTO.Score;
            grade.GradeId = GradeColumnDTO.GradeId;
            await _courseSystemDB.SaveChangesAsync();
            return new ServiceResponse(true, "update success");
        }
    }
}

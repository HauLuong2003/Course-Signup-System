﻿using Course_Signup_System.DTO.Reponse;
using Course_Signup_System.DTO;

namespace Course_Signup_System.Services
{
    public interface IGradeService
    {
        Task<GradeDTO> CreateGrade(GradeDTO GradeDTO);
        Task<ServiceResponse> UpdateGrade(int Id, GradeDTO GradeDTO);
        Task<List<GradeDTO>> GetGrade();
        Task<ServiceResponse> DeleteGradeType(int GradeId);
        Task<GradeDTO> GetGradeById(int GradeId);
        Task<List<AcademicTranscript>> GetAcademicTranscript();
        Task<AcademicTranscript> GetAcademicTranscriptByStudent(string StudentId);
        Task<GradeDTO> GetGradeByGradeType(int GradeTypeId,string studentId);
    }
}
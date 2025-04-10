﻿using Course_Signup_System.Application.DTO.Reponse;
using Course_Signup_System.Application.DTO;

namespace Course_Signup_System.Application.Services
{
    public interface IGradeTypeService
    {
        Task<GradeTypeDTO> CreateGradeType(GradeTypeDTO GradeTypeDTO);
        Task<ServiceResponse> UpdateGradeType(int Id, GradeTypeDTO GradeTypeDTO);
        Task<PageResult<GradeTypeDTO>> GetGradeType(int page, int pagesize);
        Task<ServiceResponse> DeleteGradeType(int GradeTypeId);
        Task<GradeTypeDTO> GetGradeTypeById(int GradeTypeId);
    }
}

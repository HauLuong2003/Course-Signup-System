﻿using Course_Signup_System.DTO.Reponse;
using Course_Signup_System.DTO;

namespace Course_Signup_System.Services
{
    public interface IClassService
    {
        Task<ClassDTO> CreateClass(ClassDTO classDTO);
        Task<PageResult<ClassDTO>> GetAllClass(int page, int pagesize);
        Task<ServiceResponse> DeleteClass(string ClassId);
        Task<ClassDTO> GetClassById(string ClassId);
        Task<ServiceResponse> UpdateClass(ClassDTO ClassDTO);
        Task<List<ClassDTO>> SearchClass(string name);

    }
}

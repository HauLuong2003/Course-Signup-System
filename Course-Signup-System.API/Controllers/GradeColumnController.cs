﻿using Course_Signup_System.Application.DTO;
using Course_Signup_System.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Course_Signup_System.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradeColumnController : ControllerBase
    { 
        private readonly IGradeColumnService _gradeColumnService;
        public GradeColumnController(IGradeColumnService gradeColumnService)
        {
            _gradeColumnService = gradeColumnService;
        }
        //[Authorize(Policy = "WriteGradeAuthorize")]
        [HttpPost]
        public async Task<IActionResult> CreateGradeColumn(GradeColumnDTO gradeColumnDTO)
        {
            try
            {
                var grade = await _gradeColumnService.CreateGrade(gradeColumnDTO);
                return Ok(grade);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [Authorize(Policy = "GradeAuthorize")]
        [HttpGet]
        public async Task<IActionResult> GetGradeColumn()
        {
            try
            {
                var grade = await _gradeColumnService.GetGrade();
                return Ok(grade);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [Authorize(Policy = "GradeAuthorize")]
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetGradeById(int Id)
        {
            try
            {
                var grade = await _gradeColumnService.GetGradeById(Id);
                return Ok(grade);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [Authorize(Policy = "WriteGradeAuthorize")]
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteGrade(int Id)
        {
            try
            {
                var grade = await _gradeColumnService.DeleteGradeType(Id);
                return Ok(grade);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [Authorize(Policy = "WriteGradeAuthorize")]
        [HttpPut("{Id}")]
        public async Task<IActionResult> GetGrade(int Id, GradeColumnDTO gradeColumnDTO)
        {
            try
            {
                var grade = await _gradeColumnService.UpdateGrade(Id, gradeColumnDTO);
                return Ok(grade);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}

using ClassroomApi.DTOs;
using ClassroomApi.Entities;
using ClassroomApi.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassroomApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {

        private readonly IDbService _dbService;

        public TeachersController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet]
        public ActionResult<List<TeacherDto>> GetAllTeachers()
        {
            List<Teacher> teachers = _dbService.GetAllTeachers();
            var teacherDtos = new List<TeacherDto>();
            foreach(Teacher teacher in teachers)
            {
                teacherDtos.Add(teacher.ConvertToTeacherDto());
            }
            return Ok(teacherDtos);
        }

        [HttpGet("{teacherId}")]
        public ActionResult<TeacherDto> GetTeacherById(int teacherId)
        {

            Teacher teacher = _dbService.GetTeacherById(teacherId);
            if(teacher != null)
            {
                return Ok(teacher.ConvertToTeacherDto());
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult<TeacherDto> CreateTeacher([FromBody] TeacherDto teacherDto)
        {
            Teacher teacher = teacherDto.ConvertToTeacher();
            _dbService.AddTeacher(teacher);
            return CreatedAtAction(nameof(GetTeacherById), new { teacherId = teacher.TeacherId }, teacher.ConvertToTeacherDto());
        }
    }
}

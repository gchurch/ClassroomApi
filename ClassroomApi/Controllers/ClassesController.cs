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
    public class ClassesController : ControllerBase
    {

        private readonly IDbService _dbService;

        public ClassesController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet]
        public ActionResult<List<ClassDto>> GetAllClasses()
        {
            List<Class> classes = _dbService.GetAllClasses();
            var classDtos = new List<ClassDto>();
            foreach(Class @class in classes)
            {
                classDtos.Add(@class.ConvertToDto());
            }
            return Ok(classDtos);
        }

        [HttpGet("{classId}")]
        public ActionResult<ClassDto> GetClassById(int classId)
        {

            Class @class = _dbService.GetClassById(classId);
            if (@class != null)
            {
                ClassDto classDto = @class.ConvertToDto();
                return Ok(classDto);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult<ClassDto> CreateClass([FromBody] ClassDto classDto)
        {
            Class @class = classDto.ConvertToClass();
            _dbService.AddClass(@class);
            return CreatedAtAction(nameof(GetClassById), new { ClassId = @class.ClassId }, @class.ConvertToDto());
        }

        [HttpPost("{classId}/Teachers/{teacherId}")]
        public ActionResult<TeacherClass> AddTeacherToClass(int classId, int teacherId)
        {
            var teacherClass = new TeacherClass()
            {
                ClassId = classId,
                TeacherId = teacherId
            };
            try
            {
                _dbService.AddTeacherClass(teacherClass);
                return Ok(teacherClass);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return NoContent();
            }
        }

        [HttpGet("TeacherClasses")]
        public ActionResult<List<TeacherClass>> GetAllTeacherClasses()
        {
            List<TeacherClass> teacherClasses = _dbService.GetAllTeacherClasses();
            return Ok(teacherClasses);
        }

        [HttpGet("Names")]
        public ActionResult<List<string>> GetAllClassNames()
        {
            List<string> classNames = _dbService.GetAllClassNames();
            return Ok(classNames);
        }

        [HttpGet("{className}/StudentNames")]
        public ActionResult<List<string>> GetStudentNamesInClass(string className)
        {
            try
            {
                int classId = _dbService.GetClassIdFromClassName(className);
                List<string> studentNames = _dbService.GetStudentNamesFromClass(classId);
                return Ok(studentNames);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return NotFound();
            }

        }
    }
}

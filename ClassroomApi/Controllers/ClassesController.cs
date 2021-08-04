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
        public ActionResult<List<Class>> GetAllClasses()
        {
            return Ok(_dbService.GetAllClasses());
        }

        [HttpGet("{classId}")]
        public ActionResult<Class> GetClassById(int classId)
        {

            Class @class = _dbService.GetClassById(classId);
            if (@class != null)
            {
                return Ok(@class);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult<Class> CreateClass([FromBody] Class @class)
        {
            _dbService.AddClass(@class);
            return CreatedAtAction(nameof(GetClassById), new { ClassId = @class.ClassId }, @class);
        }

        [HttpPost("{classId}/Teachers/{teacherId}")]
        public ActionResult AddTeacherToClass(int classId, int teacherId)
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
    }
}

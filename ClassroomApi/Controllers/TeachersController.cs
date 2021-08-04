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
        public ActionResult<List<Teacher>> GetAllTeachers()
        {
            return Ok(_dbService.GetAllTeachers());
        }

        [HttpGet("{teacherId}")]
        public ActionResult<Teacher> GetTeacherById(int teacherId)
        {

            Teacher teacher = _dbService.GetTeacherById(teacherId);
            if(teacher != null)
            {
                return Ok(teacher);
            }
            else
            {
                return NotFound();
            }
        }
    }
}

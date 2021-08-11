using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassroomApi.Entities;
using ClassroomApi.Interfaces;
using Microsoft.EntityFrameworkCore;
using ClassroomApi.DTOs;

namespace ClasssroomApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IDbService _dbService;

        public StudentsController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet]
        public ActionResult<List<StudentDto>> GetAllStudents()
        {
            List<Student> students = _dbService.GetAllStudents();
            var studentDtos = new List<StudentDto>();
            foreach(Student student in students)
            {
                studentDtos.Add(student.ConvertToDto());
            }
            return Ok(studentDtos);
        }

        [HttpGet("{studentId}")]
        public ActionResult<StudentDto> GetStudentById(int studentId)
        {

            Student student = _dbService.GetStudentById(studentId);
            if (student != null)
            {
                StudentDto studentDto = student.ConvertToDto();
                return Ok(studentDto);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult<StudentDto> CreateStudent([FromBody] StudentDto studentDto)
        {
            Student student = studentDto.ConvertToStudent();
            //If the foreign key contraint of the Student entity isn't met then a DbUpdateException is thrown
            try
            {
                _dbService.AddStudent(student);
                return CreatedAtAction(nameof(GetStudentById), new { StudentId = student.StudentId }, student.ConvertToDto());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return NoContent();
            }
        }
    }
}

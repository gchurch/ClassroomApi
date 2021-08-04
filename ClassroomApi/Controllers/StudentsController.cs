﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassroomApi.Entities;
using ClassroomApi.Interfaces;

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
        public ActionResult<List<Student>> GetAllStudents()
        {
            return Ok(_dbService.GetAllStudents());
        }

        [HttpGet("{studentId}")]
        public ActionResult<Student> GetStudentById(int studentId)
        {

            Student student = _dbService.GetStudentById(studentId);
            if (student != null)
            {
                return Ok(student);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult<Student> CreateStudent([FromBody] Student student)
        {
            _dbService.AddStudent(student);
            return CreatedAtAction(nameof(GetStudentById), new { StudentId = student.StudentId }, student);
        }
    }
}
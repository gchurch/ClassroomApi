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
        public List<Teacher> Get()
        {
            return _dbService.GetAllTeachers();
        }
    }
}

using ClassroomApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using ClassroomApi.Interfaces;

namespace ClassroomApi.Services
{
    public class DbService : IDbService
    {

        private readonly ClassroomContext _context;

        public DbService(ClassroomContext context)
        {
            _context = context;
            ClearDatabase();
            SeedDatabase();
        }

        private void ClearDatabase()
        {
            var query = from teacher in _context.Teachers select teacher;
            var teachers = query.ToList();
            _context.Teachers.RemoveRange(teachers);
            _context.SaveChanges();
        }

        private void SeedDatabase()
        {
            var teachers = new List<Teacher>()
            {
                new Teacher()
                {
                    FirstName = "David",
                    LastName = "Allen",
                    Age = 30,
                    Subject = "Maths"
                },
                new Teacher()
                {
                    FirstName = "Michelle",
                    LastName = "Jones",
                    Age = 26,
                    Subject = "English"
                },
                new Teacher()
                {
                    FirstName = "John",
                    LastName = "Smith",
                    Age = 35,
                    Subject = "Geography"
                }
            };
            _context.Teachers.AddRange(teachers);
            _context.SaveChanges();
        }

        public List<Teacher> GetAllTeachers()
        {
            var query = from teacher in _context.Teachers select teacher;
            var teachers = query.ToList();
            return teachers;
        }
    }
}

using ClassroomApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassroomApi.DTOs
{
    public class TeacherDto
    {
        public int TeacherId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Subject { get; set; }
        public Teacher ConvertToTeacher()
        {
            return new Teacher()
            {
                TeacherId = TeacherId,
                FirstName = FirstName,
                LastName = LastName,
                Age = Age,
                Subject = Subject
            };
        }
    }
}

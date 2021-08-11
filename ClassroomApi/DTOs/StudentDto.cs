using ClassroomApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassroomApi.DTOs
{
    public class StudentDto
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int ClassId { get; set; }

        public Student ConvertToStudent()
        {
            return new Student()
            {
                StudentId = StudentId,
                FirstName = FirstName,
                LastName = LastName,
                Age = Age,
                ClassId = ClassId
            };
        }
    }
}

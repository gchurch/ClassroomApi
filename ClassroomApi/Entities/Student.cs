using ClassroomApi.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassroomApi.Entities
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int ClassId { get; set; }
        public Class Class { get; set; }

        public StudentDto ConvertToDto()
        {
            return new StudentDto()
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

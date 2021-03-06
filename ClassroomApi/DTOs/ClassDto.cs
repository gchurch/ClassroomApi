using ClassroomApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassroomApi.DTOs
{
    public class ClassDto
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public string School { get; set; }
        public string Grade { get; set; }

        public Class ConvertToClass()
        {
            return new Class()
            {
                ClassId = ClassId,
                ClassName = ClassName,
                School = School,
                Grade = Grade
            };
        }
    }
}

using ClassroomApi.DTOs;
using System.Collections.Generic;

namespace ClassroomApi.Entities
{
    public class Class
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public string School { get; set; }
        public string Grade { get; set; }

        public List<Student> Students { get; set; }

        public ClassDto ConvertToDto()
        {
            return new ClassDto()
            {
                ClassId = ClassId,
                ClassName = ClassName,
                School = School,
                Grade = Grade
            };
        }
    }
}

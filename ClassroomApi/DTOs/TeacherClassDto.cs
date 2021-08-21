using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassroomApi.Entities;

namespace ClassroomApi.DTOs
{
    public class TeacherClassDto
    {
        public int TeacherClassId { get; set; }
        public int TeacherId { get; set; }
        public int ClassId { get; set; }

        public TeacherClass ConvertToTeacherClass()
        {
            return new TeacherClass()
            {
                TeacherClassId = TeacherClassId,
                TeacherId = TeacherId,
                ClassId = ClassId
            };
        }
    }
}

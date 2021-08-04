using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassroomApi.Entities
{
    public class Class
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public string School { get; set; }
        public string Grade { get; set; }

        public List<Student> Students { get; set; }
    }
}

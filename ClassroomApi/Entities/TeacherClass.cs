﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassroomApi.Entities
{
    public class TeacherClass
    {
        public int TeacherClassId { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public int ClassId { get; set; }
        public Class Class { get; set; }
    }
}

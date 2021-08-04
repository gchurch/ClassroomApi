using ClassroomApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassroomApi.Interfaces
{
    public interface IDbService
    {
        List<Teacher> GetAllTeachers();
        Teacher GetTeacherById(int teacherId);
        void AddTeacher(Teacher teacher);
        List<Class> GetAllClasses();
        void AddClass(Class @class);
        Class GetClassById(int classId);
        List<Student> GetAllStudents();
        Student GetStudentById(int studentId);
        void AddStudent(Student student);
    }
}

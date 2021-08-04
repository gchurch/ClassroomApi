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
        }

        public List<Teacher> GetAllTeachers()
        {
            var query = from teacher in _context.Teachers select teacher;
            var teachers = query.ToList();
            return teachers;
        }

        public Teacher GetTeacherById(int teacherId)
        {
            var query = from teacher 
                        in _context.Teachers 
                        where teacher.TeacherId == teacherId 
                        select teacher;
            var Teacher = query.AsNoTracking().FirstOrDefault();
            return Teacher;
        }

        public void AddTeacher(Teacher teacher)
        {
            teacher.TeacherId = 0;
            _context.Teachers.Add(teacher);
            _context.SaveChanges();
        }

        public List<Class> GetAllClasses()
        {
            var query = from @class in _context.Classes select @class;
            var classes = query.ToList();
            return classes;
        }

        public Class GetClassById(int classId)
        {
            var query = from @class
                        in _context.Classes
                        where @class.ClassId == classId
                        select @class;
            Class selectedClass = query.AsNoTracking().FirstOrDefault();
            return selectedClass;
        }

        public void AddClass(Class @class)
        {
            @class.ClassId = 0;
            _context.Classes.Add(@class);
            _context.SaveChanges();
        }

        public List<Student> GetAllStudents()
        {
            var query = from student in _context.Students select student;
            var students = query.ToList();
            return students;
        }

        public Student GetStudentById(int studentId)
        {
            var query = from student
                        in _context.Students
                        where student.StudentId == studentId
                        select student;
            Student selectedStudent = query.AsNoTracking().FirstOrDefault();
            return selectedStudent;
        }

        private bool DoesClassExist(int classId)
        {
            var query = from @class
                        in _context.Classes
                        where @class.ClassId == classId
                        select @class;
            bool doesClassExist = query.Any();
            return doesClassExist;
        }

        public void AddStudent(Student student)
        {
            student.StudentId = 0;
            if(DoesClassExist(student.ClassId) == false)
            {
                throw new Exception("Trying to add a student to a class that doesn't exist");
            }
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        private bool DoesTeacherExist(int teacherId)
        {
            var query = from teacher
                        in _context.Teachers
                        where teacher.TeacherId == teacherId
                        select teacher;
            return query.Any();
        }

        public void AddTeacherClass(TeacherClass teacherClass)
        {
            if(DoesClassExist(teacherClass.ClassId) == false || DoesTeacherExist(teacherClass.TeacherId) == false)
            {
                throw new Exception("class or teacher doesn't exist.");
            }
            _context.TeacherClasses.Add(teacherClass);
        }
    }
}

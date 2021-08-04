﻿using ClassroomApi;
using ClassroomApi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassroomApi
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ClassroomContext(serviceProvider.GetRequiredService<DbContextOptions<ClassroomContext>>()))
            {
                SeedDB(context);
            }
        }

        public static void SeedDB(ClassroomContext context)
        {
            // Look for any products.
            if (context.Teachers.Any())
            {
                return;     // DB has been seeded
            }

            AddTeachers(context);
            AddClasses(context);
            AddStudents(context);
        }

        private static void AddTeachers(ClassroomContext context)
        {
            var teachers = new List<Teacher>()
            {
                new Teacher()
                {
                    FirstName = "David",
                    LastName = "Allen",
                    Age = 30,
                    Subject = "Maths"
                },
                new Teacher()
                {
                    FirstName = "Michelle",
                    LastName = "Jones",
                    Age = 26,
                    Subject = "English"
                },
                new Teacher()
                {
                    FirstName = "John",
                    LastName = "Smith",
                    Age = 35,
                    Subject = "Geography"
                }
            };

            context.Teachers.AddRange(teachers);
            context.SaveChanges();
        }

        private static void AddClasses(ClassroomContext context)
        {
            var classes = new List<Class>()
            {
                new Class()
                {
                    ClassName = "Maths",
                    School = "Wilson's",
                    Grade = "A"
                }
            };

            context.Classes.AddRange(classes);
            context.SaveChanges();
        }

        private static void AddStudents(ClassroomContext context)
        {
            var students = new List<Student>()
            {
                new Student()
                {
                    FirstName = "Harry",
                    LastName = "Davidson",
                    Age = 14,
                    ClassId = 1
                },
                new Student()
                {
                    FirstName = "Kevin",
                    LastName = "Mitchell",
                    Age = 12,
                    ClassId = 1
                }
            };

            context.Students.AddRange(students);
            context.SaveChanges();
        }
    }
}

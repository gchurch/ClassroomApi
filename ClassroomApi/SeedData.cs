using ClassroomApi;
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

            context.Teachers.AddRange(Teachers);
            context.Classes.AddRange(Classes);
            context.Students.AddRange(Students);
            context.SaveChanges();
        }

        public static readonly List<Teacher> Teachers = new List<Teacher>()
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

        public static readonly List<Class> Classes = new List<Class>()
        {
            new Class()
            {
                ClassName = "Maths",
                School = "Wilson's",
                Grade = "A"
            }
        };

        public static readonly List<Student> Students = new List<Student>()
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
    }
}

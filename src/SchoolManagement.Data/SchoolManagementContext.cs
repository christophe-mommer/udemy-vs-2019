using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SchoolManagement.Data
{
    public class SchoolManagementContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        public SchoolManagementContext(DbContextOptions<SchoolManagementContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var teachers = modelBuilder.Entity<Teacher>();
            var johnDoe = new Teacher { Id = 1, Name = "John", Lastname = "Doe" };
            var johnSmith = new Teacher { Id = 2, Name = "John", Lastname = "Smith" };
            var markData = new Teacher { Id = 3, Name = "Mark", Lastname = "Data" };
            teachers.HasData(new[] { johnDoe, johnSmith, markData });

            var students = modelBuilder.Entity<Student>();
            var paulSmith = new Student { Id = 1, Name = "Paul", LastName = "Smith" };
            var jackLondon = new Student { Id = 2, Name = "Jack", LastName = "London" };
            var johnMacDonald = new Student { Id = 3, Name = "John", LastName = "MacDonald" };
            var willSharp = new Student { Id = 4, Name = "Will", LastName = "Sharp" };
            students.HasData(new[] { paulSmith, jackLondon, johnMacDonald, willSharp });

            var courses = modelBuilder.Entity<Course>();
            var csharp = new Course { Id = 1, Name = "Learn C#", Hours = 36, TeacherId = 1 };
            var wpf = new Course { Id = 2, Name = "Learn WPF", Hours = 24, TeacherId = 1 };
            var aspnet = new Course { Id = 3, Name = "Learn ASP.NET Core", Hours = 44, TeacherId = 2 };
            var efCore = new Course { Id = 4, Name = "Learn EF Core", Hours = 16, TeacherId = 3 };
            var azure = new Course { Id = 5, Name = "Learn Azure", Hours = 52, TeacherId = 3 };
            var azureDevops = new Course { Id = 6, Name = "Learn Azure DevOps", Hours = 10, TeacherId = 2 };
            courses.HasData(new[]
            {
                csharp, wpf, aspnet, efCore, azure, azureDevops
            });

            var participations = modelBuilder.Entity<CourseParticipation>();
            participations.HasKey(p => new { p.CourseId, p.StudentId });
            participations.HasData(new[]
            {
                new CourseParticipation { CourseId = 1, StudentId = 1, Notation = 13},
                new CourseParticipation { CourseId = 1, StudentId = 2, Notation = 15},
                new CourseParticipation { CourseId = 1, StudentId = 3, Notation = 8},
                new CourseParticipation { CourseId = 1, StudentId = 4, Notation = 19},
                new CourseParticipation { CourseId = 2, StudentId = 1, Notation = 11},
                new CourseParticipation { CourseId = 2, StudentId = 2, Notation = 8},
                new CourseParticipation { CourseId = 2, StudentId = 3, Notation = 5},
                new CourseParticipation { CourseId = 2, StudentId = 4, Notation = 15},
                new CourseParticipation { CourseId = 3, StudentId = 1, Notation = 17},
                new CourseParticipation { CourseId = 3, StudentId = 2, Notation = 17},
                new CourseParticipation { CourseId = 3, StudentId = 3, Notation = 16},
                new CourseParticipation { CourseId = 3, StudentId = 4, Notation = 12},
                new CourseParticipation { CourseId = 4, StudentId = 1, Notation = 11},
                new CourseParticipation { CourseId = 4, StudentId = 2, Notation = 18},
                new CourseParticipation { CourseId = 4, StudentId = 3, Notation = 12},
                new CourseParticipation { CourseId = 4, StudentId = 4, Notation = 20},
                new CourseParticipation { CourseId = 5, StudentId = 1, Notation = 11},
                new CourseParticipation { CourseId = 5, StudentId = 2, Notation = 10},
                new CourseParticipation { CourseId = 5, StudentId = 3, Notation = 11}
            });

        }
    }
}

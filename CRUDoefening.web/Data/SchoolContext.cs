using CRUDoefening.web.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDoefening.web.Data
{
    public class SchoolContext : DbContext
    {
        // define constructor to later configure context with dependency injection -- overerving van base(options) = DbContext
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {

        }

        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentInfo> StudentInfo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // restricties toepassen op properties van entities
            modelBuilder.Entity<Teacher>().Property(t => t.Name).HasMaxLength(150).IsRequired();
            modelBuilder.Entity<Teacher>().Property(t => t.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Course>().Property(c => c.Name).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Course>().Property(c => c.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Student>().Property(s => s.Name).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<StudentInfo>().Property(si => si.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<StudentInfo>().Property(si => si.Email).HasMaxLength(150).IsRequired();
            // de entiteit StudentInfo is associated met 1 Student, die op zijn beurt associated is met 1 StudentInfo
            // foreign key is StudentId
            modelBuilder.Entity<StudentInfo>().HasOne(si => si.Student).WithOne(s => s.ContactInfo).HasForeignKey<StudentInfo>(si => si.StudentId);


            //dataseeding :
            modelBuilder.Entity<Teacher>().HasData(
                new Teacher
                {
                    Id = 1,
                    Name = "Joachim",
                    YearlyWage = 115000,
                },
                new Teacher
                {
                    Id = 2,
                    Name = "Bart",
                    YearlyWage = null,                    
                }

                );

            modelBuilder.Entity<Course>().HasData(
                    new Course
                    { Id = new Guid("D3FE4B3E-4348-4D6C-950A-6B3E3749E997"),
                        Name = "Programmeren",
                        TeacherId = 1,
                        Description = "this is the description of the Programming Course",
                    },

                    new Course
                    {
                        Id = new Guid("BDFC707C-A1F6-4C49-8D1D-3C71AA41489F"),
                        Name = "Mathemathics",
                        TeacherId = 2,
                        Description = "this is the description of the mathemathics Course",                        
                    }

                );

            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    Id = 1, Name = "Brian",
                    Scholarship = null,
                    TeacherId = 1,
                    Birthdate = DateTime.ParseExact("24/06/1992", "dd/MM/yyyy",
                    CultureInfo.InvariantCulture),
                },
                    new Student
                {
                    Id = 3,
                    Name = "Jens",
                    Scholarship = null,
                    TeacherId = 1,
                    Birthdate = DateTime.ParseExact("18/02/1989", "dd/MM/yyyy",
                    CultureInfo.InvariantCulture),
                },
                    new Student
                {
                    Id = 2, Name = "Tom",
                    Scholarship = null,
                    TeacherId = 2,
                    Birthdate = DateTime.ParseExact("18/03/1990", "dd/MM/yyyy",
                    CultureInfo.InvariantCulture),
                }
                );

            modelBuilder.Entity<StudentInfo>().HasData(
                 new StudentInfo { Id = 1, StudentId = 1, Email = "brian@gmail.com"},
                 new StudentInfo { Id = 2, StudentId = 2, Email = "tom@gmail.com" },
                 new StudentInfo { Id = 3, StudentId = 3, Email = "jens@gmail.com" }
                );
        }
    }
}

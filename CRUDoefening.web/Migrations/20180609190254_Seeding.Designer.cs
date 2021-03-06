﻿// <auto-generated />
using System;
using CRUDoefening.web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CRUDoefening.web.Migrations
{
    [DbContext(typeof(SchoolContext))]
    [Migration("20180609190254_Seeding")]
    partial class Seeding
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-rtm-30799")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CRUDoefening.web.Entities.Course", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<long>("TeacherId");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.ToTable("Courses");

                    b.HasData(
                        new { Id = new Guid("d3fe4b3e-4348-4d6c-950a-6b3e3749e997"), Description = "this is the description of the Programming Course", Name = "Programmeren", TeacherId = 1L },
                        new { Id = new Guid("bdfc707c-a1f6-4c49-8d1d-3c71aa41489f"), Description = "this is the description of the mathemathics Course", Name = "Mathemathics", TeacherId = 2L }
                    );
                });

            modelBuilder.Entity("CRUDoefening.web.Entities.Student", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Birthdate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<decimal?>("Scholarship");

                    b.Property<long>("TeacherId");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.ToTable("Students");

                    b.HasData(
                        new { Id = 1L, Birthdate = new DateTime(1992, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), Name = "Brian", TeacherId = 1L },
                        new { Id = 3L, Birthdate = new DateTime(1989, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), Name = "Jens", TeacherId = 1L },
                        new { Id = 2L, Birthdate = new DateTime(1990, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), Name = "Tom", TeacherId = 2L }
                    );
                });

            modelBuilder.Entity("CRUDoefening.web.Entities.StudentInfo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<long>("StudentId");

                    b.HasKey("Id");

                    b.HasIndex("StudentId")
                        .IsUnique();

                    b.ToTable("StudentInfo");

                    b.HasData(
                        new { Id = 1L, Email = "brian@gmail.com", StudentId = 1L },
                        new { Id = 2L, Email = "tom@gmail.com", StudentId = 2L },
                        new { Id = 3L, Email = "jens@gmail.com", StudentId = 3L }
                    );
                });

            modelBuilder.Entity("CRUDoefening.web.Entities.Teacher", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<decimal?>("YearlyWage");

                    b.HasKey("Id");

                    b.ToTable("Teachers");

                    b.HasData(
                        new { Id = 1L, Name = "Joachim", YearlyWage = 115000m },
                        new { Id = 2L, Name = "Bart" }
                    );
                });

            modelBuilder.Entity("CRUDoefening.web.Entities.Course", b =>
                {
                    b.HasOne("CRUDoefening.web.Entities.Teacher", "Teacher")
                        .WithMany("Courses")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CRUDoefening.web.Entities.Student", b =>
                {
                    b.HasOne("CRUDoefening.web.Entities.Teacher", "Teacher")
                        .WithMany("Students")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CRUDoefening.web.Entities.StudentInfo", b =>
                {
                    b.HasOne("CRUDoefening.web.Entities.Student", "Student")
                        .WithOne("ContactInfo")
                        .HasForeignKey("CRUDoefening.web.Entities.StudentInfo", "StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

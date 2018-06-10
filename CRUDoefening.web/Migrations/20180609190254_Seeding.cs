using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CRUDoefening.web.Migrations
{
    public partial class Seeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Name", "YearlyWage" },
                values: new object[] { 1L, "Joachim", 115000m });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Name", "YearlyWage" },
                values: new object[] { 2L, "Bart", null });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Description", "Name", "TeacherId" },
                values: new object[,]
                {
                    { new Guid("d3fe4b3e-4348-4d6c-950a-6b3e3749e997"), "this is the description of the Programming Course", "Programmeren", 1L },
                    { new Guid("bdfc707c-a1f6-4c49-8d1d-3c71aa41489f"), "this is the description of the mathemathics Course", "Mathemathics", 2L }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Birthdate", "Name", "Scholarship", "TeacherId" },
                values: new object[,]
                {
                    { 1L, new DateTime(1992, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brian", null, 1L },
                    { 3L, new DateTime(1989, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jens", null, 1L },
                    { 2L, new DateTime(1990, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tom", null, 2L }
                });

            migrationBuilder.InsertData(
                table: "StudentInfo",
                columns: new[] { "Id", "Email", "StudentId" },
                values: new object[] { 1L, "brian@gmail.com", 1L });

            migrationBuilder.InsertData(
                table: "StudentInfo",
                columns: new[] { "Id", "Email", "StudentId" },
                values: new object[] { 3L, "jens@gmail.com", 3L });

            migrationBuilder.InsertData(
                table: "StudentInfo",
                columns: new[] { "Id", "Email", "StudentId" },
                values: new object[] { 2L, "tom@gmail.com", 2L });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("bdfc707c-a1f6-4c49-8d1d-3c71aa41489f"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("d3fe4b3e-4348-4d6c-950a-6b3e3749e997"));

            migrationBuilder.DeleteData(
                table: "StudentInfo",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "StudentInfo",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "StudentInfo",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 2L);
        }
    }
}

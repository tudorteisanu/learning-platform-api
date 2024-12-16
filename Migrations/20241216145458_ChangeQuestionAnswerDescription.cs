using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace learning_platform.Migrations
{
    /// <inheritdoc />
    public partial class ChangeQuestionAnswerDescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("4ac584b5-a309-4b43-8cdd-864b2c1c0b52"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("94a46b59-815f-4782-bd78-c6b0b3e10816"));

            migrationBuilder.RenameColumn(
                name: "Text",
                table: "Answers",
                newName: "Description");

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Description", "Language", "Level" },
                values: new object[,]
                {
                    { new Guid("13154253-b04f-401b-960e-ce43684b2d89"), "Learn basic English communication skills.", "English", "Beginner" },
                    { new Guid("5b13514e-7e5b-43df-a46f-a90edd038de4"), "Enhance your Spanish fluency.", "Spanish", "Intermediate" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("13154253-b04f-401b-960e-ce43684b2d89"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("5b13514e-7e5b-43df-a46f-a90edd038de4"));

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Answers",
                newName: "Text");

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Description", "Language", "Level" },
                values: new object[,]
                {
                    { new Guid("4ac584b5-a309-4b43-8cdd-864b2c1c0b52"), "Enhance your Spanish fluency.", "Spanish", "Intermediate" },
                    { new Guid("94a46b59-815f-4782-bd78-c6b0b3e10816"), "Learn basic English communication skills.", "English", "Beginner" }
                });
        }
    }
}

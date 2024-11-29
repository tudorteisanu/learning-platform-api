using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace learning_platform.Migrations
{
    /// <inheritdoc />
    public partial class AddLessonContent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("6e0878a7-a42d-4d7e-aaf4-7601a1a860e5"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("bf138c23-c13b-4b3b-9d5d-70116ffa06f1"));

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Description", "Language", "Level" },
                values: new object[,]
                {
                    { new Guid("9bb92490-aaee-4683-859d-2b58fa2264dd"), "Learn basic English communication skills.", "English", "Beginner" },
                    { new Guid("da30747e-874b-4913-8a2a-53c80a673d96"), "Enhance your Spanish fluency.", "Spanish", "Intermediate" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("9bb92490-aaee-4683-859d-2b58fa2264dd"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("da30747e-874b-4913-8a2a-53c80a673d96"));

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Description", "Language", "Level" },
                values: new object[,]
                {
                    { new Guid("6e0878a7-a42d-4d7e-aaf4-7601a1a860e5"), "Enhance your Spanish fluency.", "Spanish", "Intermediate" },
                    { new Guid("bf138c23-c13b-4b3b-9d5d-70116ffa06f1"), "Learn basic English communication skills.", "English", "Beginner" }
                });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace learning_platform.Migrations
{
    /// <inheritdoc />
    public partial class AddLessonContentRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("9bb92490-aaee-4683-859d-2b58fa2264dd"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("da30747e-874b-4913-8a2a-53c80a673d96"));

            migrationBuilder.DropColumn(
                name: "Content",
                table: "Lessons");

            migrationBuilder.CreateTable(
                name: "LessonContent",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LessonId = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: true),
                    Position = table.Column<int>(type: "integer", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Data = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonContent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LessonContent_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Description", "Language", "Level" },
                values: new object[,]
                {
                    { new Guid("bf35b01b-b37f-445c-951c-fa21e90d2092"), "Enhance your Spanish fluency.", "Spanish", "Intermediate" },
                    { new Guid("c5574a9f-c79c-439f-9cb7-315d367144d3"), "Learn basic English communication skills.", "English", "Beginner" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_LessonContent_LessonId",
                table: "LessonContent",
                column: "LessonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LessonContent");

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("bf35b01b-b37f-445c-951c-fa21e90d2092"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("c5574a9f-c79c-439f-9cb7-315d367144d3"));

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Lessons",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Description", "Language", "Level" },
                values: new object[,]
                {
                    { new Guid("9bb92490-aaee-4683-859d-2b58fa2264dd"), "Learn basic English communication skills.", "English", "Beginner" },
                    { new Guid("da30747e-874b-4913-8a2a-53c80a673d96"), "Enhance your Spanish fluency.", "Spanish", "Intermediate" }
                });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Course_Signup_System.Migrations
{
    public partial class fixStudentClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentClasses_StudentClasses_StudentClassId1",
                table: "StudentClasses");

            migrationBuilder.DropIndex(
                name: "IX_StudentClasses_StudentClassId1",
                table: "StudentClasses");

            migrationBuilder.DropColumn(
                name: "StudentClassId1",
                table: "StudentClasses");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAt",
                table: "StudentClasses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "StudentClasses");

            migrationBuilder.AddColumn<int>(
                name: "StudentClassId1",
                table: "StudentClasses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentClasses_StudentClassId1",
                table: "StudentClasses",
                column: "StudentClassId1");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentClasses_StudentClasses_StudentClassId1",
                table: "StudentClasses",
                column: "StudentClassId1",
                principalTable: "StudentClasses",
                principalColumn: "StudentClassId");
        }
    }
}

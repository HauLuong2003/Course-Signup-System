using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Course_Signup_System.Migrations
{
    public partial class version12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "EndStudy",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "StartStudy",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "Departments");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndStudy",
                table: "ClassOf",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartStudy",
                table: "ClassOf",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndStudy",
                table: "ClassOf");

            migrationBuilder.DropColumn(
                name: "StartStudy",
                table: "ClassOf");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAt",
                table: "Departments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EndStudy",
                table: "Departments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartStudy",
                table: "Departments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "Departments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}

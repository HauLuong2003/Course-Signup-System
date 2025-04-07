using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Course_Signup_System.Infrastructure.Migrations
{
    public partial class version18 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClassRoom",
                table: "TeachSchedules",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "StudyTimeEnd",
                table: "TeachSchedules",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClassRoom",
                table: "TeachSchedules");

            migrationBuilder.DropColumn(
                name: "StudyTimeEnd",
                table: "TeachSchedules");
        }
    }
}

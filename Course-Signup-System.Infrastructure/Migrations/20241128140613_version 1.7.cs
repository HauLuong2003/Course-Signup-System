using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Course_Signup_System.Infrastructure.Migrations
{
    public partial class version17 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAt",
                table: "EmployeeSalaries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "TotalSalary",
                table: "EmployeeSalaries",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "EmployeeSalaries");

            migrationBuilder.DropColumn(
                name: "TotalSalary",
                table: "EmployeeSalaries");
        }
    }
}

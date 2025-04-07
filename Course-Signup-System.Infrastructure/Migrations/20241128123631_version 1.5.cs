using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Course_Signup_System.Infrastructure.Migrations
{
    public partial class version15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeSalary_Teachers_TeacherUserId",
                table: "EmployeeSalary");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeSalary",
                table: "EmployeeSalary");

            migrationBuilder.RenameTable(
                name: "EmployeeSalary",
                newName: "EmployeeSalaries");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeSalary_TeacherUserId",
                table: "EmployeeSalaries",
                newName: "IX_EmployeeSalaries_TeacherUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeSalaries",
                table: "EmployeeSalaries",
                column: "EmployeeSalaryId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeSalaries_Teachers_TeacherUserId",
                table: "EmployeeSalaries",
                column: "TeacherUserId",
                principalTable: "Teachers",
                principalColumn: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeSalaries_Teachers_TeacherUserId",
                table: "EmployeeSalaries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeSalaries",
                table: "EmployeeSalaries");

            migrationBuilder.RenameTable(
                name: "EmployeeSalaries",
                newName: "EmployeeSalary");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeSalaries_TeacherUserId",
                table: "EmployeeSalary",
                newName: "IX_EmployeeSalary_TeacherUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeSalary",
                table: "EmployeeSalary",
                column: "EmployeeSalaryId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeSalary_Teachers_TeacherUserId",
                table: "EmployeeSalary",
                column: "TeacherUserId",
                principalTable: "Teachers",
                principalColumn: "UserId");
        }
    }
}

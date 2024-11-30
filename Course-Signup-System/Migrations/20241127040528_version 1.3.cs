using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Course_Signup_System.Migrations
{
    public partial class version13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grade_GradeTypes_GradeTypeId",
                table: "Grade");

            migrationBuilder.DropForeignKey(
                name: "FK_Grade_Students_UserId",
                table: "Grade");

            migrationBuilder.DropForeignKey(
                name: "FK_Grade_Subjects_SubjectId",
                table: "Grade");

            migrationBuilder.DropForeignKey(
                name: "FK_GradeColumns_Grade_GradeId",
                table: "GradeColumns");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Grade",
                table: "Grade");

            migrationBuilder.RenameTable(
                name: "Grade",
                newName: "Grades");

            migrationBuilder.RenameIndex(
                name: "IX_Grade_UserId",
                table: "Grades",
                newName: "IX_Grades_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Grade_SubjectId",
                table: "Grades",
                newName: "IX_Grades_SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Grade_GradeTypeId",
                table: "Grades",
                newName: "IX_Grades_GradeTypeId");

            migrationBuilder.AddColumn<double>(
                name: "EffectiveChargeRate",
                table: "PayTuitions",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Grades",
                table: "Grades",
                column: "GradeId");

            migrationBuilder.AddForeignKey(
                name: "FK_GradeColumns_Grades_GradeId",
                table: "GradeColumns",
                column: "GradeId",
                principalTable: "Grades",
                principalColumn: "GradeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_GradeTypes_GradeTypeId",
                table: "Grades",
                column: "GradeTypeId",
                principalTable: "GradeTypes",
                principalColumn: "GradeTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Students_UserId",
                table: "Grades",
                column: "UserId",
                principalTable: "Students",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Subjects_SubjectId",
                table: "Grades",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "SubjectId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GradeColumns_Grades_GradeId",
                table: "GradeColumns");

            migrationBuilder.DropForeignKey(
                name: "FK_Grades_GradeTypes_GradeTypeId",
                table: "Grades");

            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Students_UserId",
                table: "Grades");

            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Subjects_SubjectId",
                table: "Grades");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Grades",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "EffectiveChargeRate",
                table: "PayTuitions");

            migrationBuilder.RenameTable(
                name: "Grades",
                newName: "Grade");

            migrationBuilder.RenameIndex(
                name: "IX_Grades_UserId",
                table: "Grade",
                newName: "IX_Grade_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Grades_SubjectId",
                table: "Grade",
                newName: "IX_Grade_SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Grades_GradeTypeId",
                table: "Grade",
                newName: "IX_Grade_GradeTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Grade",
                table: "Grade",
                column: "GradeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Grade_GradeTypes_GradeTypeId",
                table: "Grade",
                column: "GradeTypeId",
                principalTable: "GradeTypes",
                principalColumn: "GradeTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Grade_Students_UserId",
                table: "Grade",
                column: "UserId",
                principalTable: "Students",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Grade_Subjects_SubjectId",
                table: "Grade",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "SubjectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GradeColumns_Grade_GradeId",
                table: "GradeColumns",
                column: "GradeId",
                principalTable: "Grade",
                principalColumn: "GradeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

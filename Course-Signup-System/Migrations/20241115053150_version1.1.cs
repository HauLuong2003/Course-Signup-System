using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Course_Signup_System.Migrations
{
    public partial class version11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discount",
                table: "StudentClasses");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "StudentClasses");

            migrationBuilder.DropColumn(
                name: "Surcharge",
                table: "StudentClasses");

            migrationBuilder.DropColumn(
                name: "Tuition",
                table: "StudentClasses");

            migrationBuilder.DropColumn(
                name: "Score",
                table: "Grade");

            migrationBuilder.AddColumn<bool>(
                name: "IsActived",
                table: "SubjectClasses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "StudentClassId1",
                table: "StudentClasses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GradeColumns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Score = table.Column<double>(type: "float", nullable: false),
                    GradeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradeColumns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GradeColumns_Grade_GradeId",
                        column: x => x.GradeId,
                        principalTable: "Grade",
                        principalColumn: "GradeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PayTuitions",
                columns: table => new
                {
                    PayTuitionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tuition = table.Column<double>(type: "float", nullable: false),
                    Discount = table.Column<double>(type: "float", nullable: false),
                    Surcharge = table.Column<double>(type: "float", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentClassId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayTuitions", x => x.PayTuitionId);
                    table.ForeignKey(
                        name: "FK_PayTuitions_StudentClasses_StudentClassId",
                        column: x => x.StudentClassId,
                        principalTable: "StudentClasses",
                        principalColumn: "StudentClassId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentClasses_StudentClassId1",
                table: "StudentClasses",
                column: "StudentClassId1");

            migrationBuilder.CreateIndex(
                name: "IX_GradeColumns_GradeId",
                table: "GradeColumns",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_PayTuitions_StudentClassId",
                table: "PayTuitions",
                column: "StudentClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentClasses_StudentClasses_StudentClassId1",
                table: "StudentClasses",
                column: "StudentClassId1",
                principalTable: "StudentClasses",
                principalColumn: "StudentClassId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentClasses_StudentClasses_StudentClassId1",
                table: "StudentClasses");

            migrationBuilder.DropTable(
                name: "GradeColumns");

            migrationBuilder.DropTable(
                name: "PayTuitions");

            migrationBuilder.DropIndex(
                name: "IX_StudentClasses_StudentClassId1",
                table: "StudentClasses");

            migrationBuilder.DropColumn(
                name: "IsActived",
                table: "SubjectClasses");

            migrationBuilder.DropColumn(
                name: "StudentClassId1",
                table: "StudentClasses");

            migrationBuilder.AddColumn<double>(
                name: "Discount",
                table: "StudentClasses",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "StudentClasses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Surcharge",
                table: "StudentClasses",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Tuition",
                table: "StudentClasses",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Score",
                table: "Grade",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Course_Signup_System.Migrations
{
    public partial class version12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TuitionTypeId",
                table: "PayTuitions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TuitionTypes",
                columns: table => new
                {
                    TuitionTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TuitionName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TuitionTypes", x => x.TuitionTypeId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PayTuitions_TuitionTypeId",
                table: "PayTuitions",
                column: "TuitionTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_PayTuitions_TuitionTypes_TuitionTypeId",
                table: "PayTuitions",
                column: "TuitionTypeId",
                principalTable: "TuitionTypes",
                principalColumn: "TuitionTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PayTuitions_TuitionTypes_TuitionTypeId",
                table: "PayTuitions");

            migrationBuilder.DropTable(
                name: "TuitionTypes");

            migrationBuilder.DropIndex(
                name: "IX_PayTuitions_TuitionTypeId",
                table: "PayTuitions");

            migrationBuilder.DropColumn(
                name: "TuitionTypeId",
                table: "PayTuitions");
        }
    }
}

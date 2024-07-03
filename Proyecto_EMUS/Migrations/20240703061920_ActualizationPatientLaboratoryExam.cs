using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto_EMUS.Migrations
{
    /// <inheritdoc />
    public partial class ActualizationPatientLaboratoryExam : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Patient");

            migrationBuilder.RenameColumn(
                name: "FileUrl",
                table: "LaboratoryExams",
                newName: "Name");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "LaboratoryExams",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "PatientLaboratoryExam",
                columns: table => new
                {
                    IdPatient = table.Column<int>(type: "int", nullable: false),
                    IdLaboratoryExam = table.Column<int>(type: "int", nullable: false),
                    FileUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientLaboratoryExam", x => new { x.IdPatient, x.IdLaboratoryExam });
                    table.ForeignKey(
                        name: "FK_PatientLaboratoryExam_LaboratoryExams_IdLaboratoryExam",
                        column: x => x.IdLaboratoryExam,
                        principalTable: "LaboratoryExams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientLaboratoryExam_Patient_IdPatient",
                        column: x => x.IdPatient,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PatientLaboratoryExam_IdLaboratoryExam",
                table: "PatientLaboratoryExam",
                column: "IdLaboratoryExam");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PatientLaboratoryExam");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "LaboratoryExams",
                newName: "FileUrl");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Patient",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "LaboratoryExams",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto_EMUS.Data.Migra
{
    /// <inheritdoc />
    public partial class RemoveFKDoctorPatient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patient_Doctor_AttendingDoctor",
                table: "Patient");

            migrationBuilder.DropIndex(
                name: "IX_Patient_AttendingDoctor",
                table: "Patient");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Patient_AttendingDoctor",
                table: "Patient",
                column: "AttendingDoctor");

            migrationBuilder.AddForeignKey(
                name: "FK_Patient_Doctor_AttendingDoctor",
                table: "Patient",
                column: "AttendingDoctor",
                principalTable: "Doctor",
                principalColumn: "GMCNumber");
        }
    }
}

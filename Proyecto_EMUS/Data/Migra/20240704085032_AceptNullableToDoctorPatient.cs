using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto_EMUS.Data.Migra
{
    /// <inheritdoc />
    public partial class AceptNullableToDoctorPatient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patient_Doctor_AttendingDoctor",
                table: "Patient");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastAttendDate",
                table: "Patient",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "AttendingDoctor",
                table: "Patient",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Patient_Doctor_AttendingDoctor",
                table: "Patient",
                column: "AttendingDoctor",
                principalTable: "Doctor",
                principalColumn: "GMCNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patient_Doctor_AttendingDoctor",
                table: "Patient");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastAttendDate",
                table: "Patient",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AttendingDoctor",
                table: "Patient",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Patient_Doctor_AttendingDoctor",
                table: "Patient",
                column: "AttendingDoctor",
                principalTable: "Doctor",
                principalColumn: "GMCNumber",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

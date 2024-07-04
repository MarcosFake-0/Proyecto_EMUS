using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto_EMUS.Data.Migra
{
    /// <inheritdoc />
    public partial class ImplementationDoctorInformation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "ClinicalHistoryNotes",
                newName: "CreatedAt");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "PatientTreatment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatedByDoctorId",
                table: "PatientTreatment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "PatientTreatment",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "PatientMedication",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatedByDoctorId",
                table: "PatientMedication",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "PatientMedication",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "PatientLaboratoryExam",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatedByDoctorId",
                table: "PatientLaboratoryExam",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "PatientConditions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatedByDoctorId",
                table: "PatientConditions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "PatientConditions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Doctor",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByDoctorId",
                table: "ClinicalHistoryNotes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "PatientTreatment");

            migrationBuilder.DropColumn(
                name: "CreatedByDoctorId",
                table: "PatientTreatment");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "PatientTreatment");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "PatientMedication");

            migrationBuilder.DropColumn(
                name: "CreatedByDoctorId",
                table: "PatientMedication");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "PatientMedication");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "PatientLaboratoryExam");

            migrationBuilder.DropColumn(
                name: "CreatedByDoctorId",
                table: "PatientLaboratoryExam");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "PatientConditions");

            migrationBuilder.DropColumn(
                name: "CreatedByDoctorId",
                table: "PatientConditions");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "PatientConditions");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Doctor");

            migrationBuilder.DropColumn(
                name: "CreatedByDoctorId",
                table: "ClinicalHistoryNotes");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "ClinicalHistoryNotes",
                newName: "DateTime");
        }
    }
}

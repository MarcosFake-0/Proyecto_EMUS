using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto_EMUS.Migrations
{
    /// <inheritdoc />
    public partial class ModificationPatientLaboratoryExam : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PatientLaboratoryExam",
                table: "PatientLaboratoryExam");

            migrationBuilder.AlterColumn<int>(
                name: "IdLaboratoryExam",
                table: "PatientLaboratoryExam",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<int>(
                name: "IdPatient",
                table: "PatientLaboratoryExam",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("Relational:ColumnOrder", 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "PatientLaboratoryExam",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "ExamDate",
                table: "PatientLaboratoryExam",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_PatientLaboratoryExam",
                table: "PatientLaboratoryExam",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PatientLaboratoryExam_IdPatient",
                table: "PatientLaboratoryExam",
                column: "IdPatient");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PatientLaboratoryExam",
                table: "PatientLaboratoryExam");

            migrationBuilder.DropIndex(
                name: "IX_PatientLaboratoryExam_IdPatient",
                table: "PatientLaboratoryExam");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "PatientLaboratoryExam");

            migrationBuilder.DropColumn(
                name: "ExamDate",
                table: "PatientLaboratoryExam");

            migrationBuilder.AlterColumn<int>(
                name: "IdPatient",
                table: "PatientLaboratoryExam",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 0);

            migrationBuilder.AlterColumn<int>(
                name: "IdLaboratoryExam",
                table: "PatientLaboratoryExam",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PatientLaboratoryExam",
                table: "PatientLaboratoryExam",
                columns: new[] { "IdPatient", "IdLaboratoryExam" });
        }
    }
}

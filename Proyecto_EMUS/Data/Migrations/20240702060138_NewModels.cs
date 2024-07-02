using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto_EMUS.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Specialty_Doctor_DoctorId",
                table: "Specialty");

            migrationBuilder.DropIndex(
                name: "IX_Specialty_DoctorId",
                table: "Specialty");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "Specialty");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Doctor",
                newName: "GMCNumber");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "DayOfBirth",
                table: "Patient",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateTable(
                name: "Treatment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treatment", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Treatment");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Specialty",
                newName: "GMCNumber");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Patient",
                newName: "GMCNumber");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Conditions",
                newName: "GMCNumber");

            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "Specialty",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DayOfBirth",
                table: "Patient",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.CreateIndex(
                name: "IX_Specialty_DoctorId",
                table: "Specialty",
                column: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Specialty_Doctor_DoctorId",
                table: "Specialty",
                column: "DoctorId",
                principalTable: "Doctor",
                principalColumn: "GMCNumber");
        }
    }
}

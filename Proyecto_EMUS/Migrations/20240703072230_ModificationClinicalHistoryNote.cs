using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto_EMUS.Migrations
{
    /// <inheritdoc />
    public partial class ModificationClinicalHistoryNote : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClinicalHistoryId",
                table: "ClinicalHistoryNotes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ClinicalHistoryNotes_ClinicalHistoryId",
                table: "ClinicalHistoryNotes",
                column: "ClinicalHistoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClinicalHistoryNotes_ClinicalHistories_ClinicalHistoryId",
                table: "ClinicalHistoryNotes",
                column: "ClinicalHistoryId",
                principalTable: "ClinicalHistories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClinicalHistoryNotes_ClinicalHistories_ClinicalHistoryId",
                table: "ClinicalHistoryNotes");

            migrationBuilder.DropIndex(
                name: "IX_ClinicalHistoryNotes_ClinicalHistoryId",
                table: "ClinicalHistoryNotes");

            migrationBuilder.DropColumn(
                name: "ClinicalHistoryId",
                table: "ClinicalHistoryNotes");
        }
    }
}

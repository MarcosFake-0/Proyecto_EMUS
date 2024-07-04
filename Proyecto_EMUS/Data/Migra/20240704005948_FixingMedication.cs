using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto_EMUS.Data.Migra
{
    /// <inheritdoc />
    public partial class FixingMedication : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Medications",
                newName: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

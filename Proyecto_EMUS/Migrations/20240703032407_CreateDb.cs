using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto_EMUS.Migrations
{
    /// <inheritdoc />
    public partial class CreateDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClinicalHistoryNotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClinicalHistoryNotes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Conditions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conditions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Doctor",
                columns: table => new
                {
                    GMCNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UrlImage = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor", x => x.GMCNumber);
                });

            migrationBuilder.CreateTable(
                name: "Drugs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drugs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LaboratoryExams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaboratoryExams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Specialty",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialty", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DayOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CivilStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AttendingDoctor = table.Column<int>(type: "int", nullable: false),
                    LastAttendDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patient_Doctor_AttendingDoctor",
                        column: x => x.AttendingDoctor,
                        principalTable: "Doctor",
                        principalColumn: "GMCNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DoctorSpecialty",
                columns: table => new
                {
                    GMCNumber = table.Column<int>(type: "int", nullable: false),
                    IdSpecialty = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorSpecialty", x => new { x.GMCNumber, x.IdSpecialty });
                    table.ForeignKey(
                        name: "FK_DoctorSpecialty_Doctor_GMCNumber",
                        column: x => x.GMCNumber,
                        principalTable: "Doctor",
                        principalColumn: "GMCNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorSpecialty_Specialty_IdSpecialty",
                        column: x => x.IdSpecialty,
                        principalTable: "Specialty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClinicalHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClinicalHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClinicalHistories_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatientConditions",
                columns: table => new
                {
                    IdPatient = table.Column<int>(type: "int", nullable: false),
                    IdCondition = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientConditions", x => new { x.IdPatient, x.IdCondition });
                    table.ForeignKey(
                        name: "FK_PatientConditions_Conditions_IdCondition",
                        column: x => x.IdCondition,
                        principalTable: "Conditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientConditions_Patient_IdPatient",
                        column: x => x.IdPatient,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatientMedication",
                columns: table => new
                {
                    IdPatient = table.Column<int>(type: "int", nullable: false),
                    IdMedication = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientMedication", x => new { x.IdPatient, x.IdMedication });
                    table.ForeignKey(
                        name: "FK_PatientMedication_Medications_IdMedication",
                        column: x => x.IdMedication,
                        principalTable: "Medications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientMedication_Patient_IdPatient",
                        column: x => x.IdPatient,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatientTreatment",
                columns: table => new
                {
                    IdPatient = table.Column<int>(type: "int", nullable: false),
                    IdTreatment = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientTreatment", x => new { x.IdPatient, x.IdTreatment });
                    table.ForeignKey(
                        name: "FK_PatientTreatment_Patient_IdPatient",
                        column: x => x.IdPatient,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientTreatment_Treatment_IdTreatment",
                        column: x => x.IdTreatment,
                        principalTable: "Treatment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClinicalHistories_PatientId",
                table: "ClinicalHistories",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorSpecialty_IdSpecialty",
                table: "DoctorSpecialty",
                column: "IdSpecialty");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_AttendingDoctor",
                table: "Patient",
                column: "AttendingDoctor");

            migrationBuilder.CreateIndex(
                name: "IX_PatientConditions_IdCondition",
                table: "PatientConditions",
                column: "IdCondition");

            migrationBuilder.CreateIndex(
                name: "IX_PatientMedication_IdMedication",
                table: "PatientMedication",
                column: "IdMedication");

            migrationBuilder.CreateIndex(
                name: "IX_PatientTreatment_IdTreatment",
                table: "PatientTreatment",
                column: "IdTreatment");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClinicalHistories");

            migrationBuilder.DropTable(
                name: "ClinicalHistoryNotes");

            migrationBuilder.DropTable(
                name: "DoctorSpecialty");

            migrationBuilder.DropTable(
                name: "Drugs");

            migrationBuilder.DropTable(
                name: "LaboratoryExams");

            migrationBuilder.DropTable(
                name: "PatientConditions");

            migrationBuilder.DropTable(
                name: "PatientMedication");

            migrationBuilder.DropTable(
                name: "PatientTreatment");

            migrationBuilder.DropTable(
                name: "Specialty");

            migrationBuilder.DropTable(
                name: "Conditions");

            migrationBuilder.DropTable(
                name: "Medications");

            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropTable(
                name: "Treatment");

            migrationBuilder.DropTable(
                name: "Doctor");
        }
    }
}

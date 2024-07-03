﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Proyecto_EMUS.Data;

#nullable disable

namespace Proyecto_EMUS.Data.Migra
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20240703210544_Adding_Model_ApplicationUserToDb")]
    partial class Adding_Model_ApplicationUserToDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("nvarchar(21)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Proyecto_EMUS.Models.ClinicalHistoryNote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PatientId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.ToTable("ClinicalHistoryNotes");
                });

            modelBuilder.Entity("Proyecto_EMUS.Models.Conditions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Conditions");
                });

            modelBuilder.Entity("Proyecto_EMUS.Models.Doctor", b =>
                {
                    b.Property<int>("GMCNumber")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UrlImage")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GMCNumber");

                    b.ToTable("Doctor");
                });

            modelBuilder.Entity("Proyecto_EMUS.Models.DoctorSpecialty", b =>
                {
                    b.Property<int>("GMCNumber")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<int>("IdSpecialty")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.HasKey("GMCNumber", "IdSpecialty");

                    b.HasIndex("IdSpecialty");

                    b.ToTable("DoctorSpecialty");
                });

            modelBuilder.Entity("Proyecto_EMUS.Models.Drug", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Drugs");
                });

            modelBuilder.Entity("Proyecto_EMUS.Models.LaboratoryExam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LaboratoryExams");
                });

            modelBuilder.Entity("Proyecto_EMUS.Models.Medication", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Medications");
                });

            modelBuilder.Entity("Proyecto_EMUS.Models.Patient", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AttendingDoctor")
                        .HasColumnType("int");

                    b.Property<string>("CivilStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("DayOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("LastAttendDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("AttendingDoctor");

                    b.ToTable("Patient");
                });

            modelBuilder.Entity("Proyecto_EMUS.Models.PatientCondition", b =>
                {
                    b.Property<string>("IdPatient")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnOrder(0);

                    b.Property<int>("IdCondition")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.HasKey("IdPatient", "IdCondition");

                    b.HasIndex("IdCondition");

                    b.ToTable("PatientConditions");
                });

            modelBuilder.Entity("Proyecto_EMUS.Models.PatientLaboratoryExam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("ExamDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FileUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdLaboratoryExam")
                        .HasColumnType("int");

                    b.Property<string>("IdPatient")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("IdLaboratoryExam");

                    b.HasIndex("IdPatient");

                    b.ToTable("PatientLaboratoryExam");
                });

            modelBuilder.Entity("Proyecto_EMUS.Models.PatientMedication", b =>
                {
                    b.Property<string>("IdPatient")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnOrder(0);

                    b.Property<int>("IdMedication")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.HasKey("IdPatient", "IdMedication");

                    b.HasIndex("IdMedication");

                    b.ToTable("PatientMedication");
                });

            modelBuilder.Entity("Proyecto_EMUS.Models.PatientTreatment", b =>
                {
                    b.Property<string>("IdPatient")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnOrder(0);

                    b.Property<int>("IdTreatment")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.HasKey("IdPatient", "IdTreatment");

                    b.HasIndex("IdTreatment");

                    b.ToTable("PatientTreatment");
                });

            modelBuilder.Entity("Proyecto_EMUS.Models.Specialty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Specialty");
                });

            modelBuilder.Entity("Proyecto_EMUS.Models.Treatment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Treatment");
                });

            modelBuilder.Entity("Proyecto_EMUS.Models.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("address")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("ApplicationUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Proyecto_EMUS.Models.ClinicalHistoryNote", b =>
                {
                    b.HasOne("Proyecto_EMUS.Models.Patient", "Patient")
                        .WithMany("ClinicalHistoryNotes")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Proyecto_EMUS.Models.DoctorSpecialty", b =>
                {
                    b.HasOne("Proyecto_EMUS.Models.Doctor", "Doctor")
                        .WithMany("DoctorSpecialties")
                        .HasForeignKey("GMCNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Proyecto_EMUS.Models.Specialty", "Specialty")
                        .WithMany()
                        .HasForeignKey("IdSpecialty")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Specialty");
                });

            modelBuilder.Entity("Proyecto_EMUS.Models.Patient", b =>
                {
                    b.HasOne("Proyecto_EMUS.Models.Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("AttendingDoctor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");
                });

            modelBuilder.Entity("Proyecto_EMUS.Models.PatientCondition", b =>
                {
                    b.HasOne("Proyecto_EMUS.Models.Conditions", "Conditions")
                        .WithMany()
                        .HasForeignKey("IdCondition")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Proyecto_EMUS.Models.Patient", "Patient")
                        .WithMany("PatientConditions")
                        .HasForeignKey("IdPatient")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Conditions");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Proyecto_EMUS.Models.PatientLaboratoryExam", b =>
                {
                    b.HasOne("Proyecto_EMUS.Models.LaboratoryExam", "LaboratoryExam")
                        .WithMany()
                        .HasForeignKey("IdLaboratoryExam")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Proyecto_EMUS.Models.Patient", "Patient")
                        .WithMany("PatientLaboratoryExams")
                        .HasForeignKey("IdPatient")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LaboratoryExam");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Proyecto_EMUS.Models.PatientMedication", b =>
                {
                    b.HasOne("Proyecto_EMUS.Models.Medication", "Medication")
                        .WithMany()
                        .HasForeignKey("IdMedication")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Proyecto_EMUS.Models.Patient", "Patient")
                        .WithMany("PatientMedication")
                        .HasForeignKey("IdPatient")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Medication");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Proyecto_EMUS.Models.PatientTreatment", b =>
                {
                    b.HasOne("Proyecto_EMUS.Models.Patient", "Patient")
                        .WithMany("PatientTreatments")
                        .HasForeignKey("IdPatient")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Proyecto_EMUS.Models.Treatment", "Treatment")
                        .WithMany()
                        .HasForeignKey("IdTreatment")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");

                    b.Navigation("Treatment");
                });

            modelBuilder.Entity("Proyecto_EMUS.Models.Doctor", b =>
                {
                    b.Navigation("DoctorSpecialties");
                });

            modelBuilder.Entity("Proyecto_EMUS.Models.Patient", b =>
                {
                    b.Navigation("ClinicalHistoryNotes");

                    b.Navigation("PatientConditions");

                    b.Navigation("PatientLaboratoryExams");

                    b.Navigation("PatientMedication");

                    b.Navigation("PatientTreatments");
                });
#pragma warning restore 612, 618
        }
    }
}

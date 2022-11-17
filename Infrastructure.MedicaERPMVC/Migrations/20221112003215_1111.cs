using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.MedicaERPMVC.Migrations
{
    public partial class _1111 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Clinics_ClinicId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_SpecializationOfDoctors_SpecialitzationOfDoctorId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Visits_AspNetUsers_PatientId",
                table: "Visits");

            migrationBuilder.DropForeignKey(
                name: "FK_Visits_AspNetUsers_UserOfClinicId",
                table: "Visits");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ClinicId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_SpecialitzationOfDoctorId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Adnotations",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ClinicId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DateOfCreation",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DateOfModification",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsPatient",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "OwnPicture",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Pesel",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RoleOfUser",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Sex",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SpecialitzationOfDoctorId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "isActivate",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "isDoctor",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "UserOfClinics",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(65)", maxLength: 65, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(65)", maxLength: 65, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Sex = table.Column<int>(type: "int", nullable: true),
                    IsPatient = table.Column<bool>(type: "bit", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adnotations = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isDoctor = table.Column<bool>(type: "bit", nullable: false),
                    RoleOfUser = table.Column<int>(type: "int", nullable: true),
                    isActivate = table.Column<bool>(type: "bit", nullable: true),
                    OwnPicture = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Pesel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClinicId = table.Column<int>(type: "int", nullable: true),
                    DateOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfModification = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SpecialitzationOfDoctorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOfClinics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserOfClinics_Clinics_ClinicId",
                        column: x => x.ClinicId,
                        principalTable: "Clinics",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserOfClinics_SpecializationOfDoctors_SpecialitzationOfDoctorId",
                        column: x => x.SpecialitzationOfDoctorId,
                        principalTable: "SpecializationOfDoctors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserOfClinics_ClinicId",
                table: "UserOfClinics",
                column: "ClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOfClinics_SpecialitzationOfDoctorId",
                table: "UserOfClinics",
                column: "SpecialitzationOfDoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_UserOfClinics_PatientId",
                table: "Visits",
                column: "PatientId",
                principalTable: "UserOfClinics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_UserOfClinics_UserOfClinicId",
                table: "Visits",
                column: "UserOfClinicId",
                principalTable: "UserOfClinics",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visits_UserOfClinics_PatientId",
                table: "Visits");

            migrationBuilder.DropForeignKey(
                name: "FK_Visits_UserOfClinics_UserOfClinicId",
                table: "Visits");

            migrationBuilder.DropTable(
                name: "UserOfClinics");

            migrationBuilder.AddColumn<string>(
                name: "Adnotations",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClinicId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfCreation",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfModification",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(65)",
                maxLength: 65,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsPatient",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(65)",
                maxLength: 65,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<byte[]>(
                name: "OwnPicture",
                table: "AspNetUsers",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Pesel",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoleOfUser",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sex",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SpecialitzationOfDoctorId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isActivate",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isDoctor",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ClinicId",
                table: "AspNetUsers",
                column: "ClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_SpecialitzationOfDoctorId",
                table: "AspNetUsers",
                column: "SpecialitzationOfDoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Clinics_ClinicId",
                table: "AspNetUsers",
                column: "ClinicId",
                principalTable: "Clinics",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_SpecializationOfDoctors_SpecialitzationOfDoctorId",
                table: "AspNetUsers",
                column: "SpecialitzationOfDoctorId",
                principalTable: "SpecializationOfDoctors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_AspNetUsers_PatientId",
                table: "Visits",
                column: "PatientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_AspNetUsers_UserOfClinicId",
                table: "Visits",
                column: "UserOfClinicId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}

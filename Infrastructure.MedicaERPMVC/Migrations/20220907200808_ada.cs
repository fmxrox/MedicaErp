using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.MedicaERPMVC.Migrations
{
    public partial class ada : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DoctorId1",
                table: "Visits",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DoctorId3",
                table: "Visits",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Doctor_Adnotations",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Doctor_ClinicId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Doctor_DateOfBirth",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Doctor_DateOfCreation",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Doctor_DateOfModification",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Doctor_FirstName",
                table: "AspNetUsers",
                type: "nvarchar(65)",
                maxLength: 65,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Doctor_IsPatient",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Doctor_LastName",
                table: "AspNetUsers",
                type: "nvarchar(65)",
                maxLength: 65,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Doctor_OwnPicture",
                table: "AspNetUsers",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Doctor_Pesel",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Doctor_RoleOfUser",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Doctor_Sex",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Doctor_SpecializationId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Doctor_isActivate",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Doctor_isDoctor",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SpecialitzationOfDoctorId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Visits_DoctorId1",
                table: "Visits",
                column: "DoctorId1");

            migrationBuilder.CreateIndex(
                name: "IX_Visits_DoctorId3",
                table: "Visits",
                column: "DoctorId3");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Doctor_ClinicId",
                table: "AspNetUsers",
                column: "Doctor_ClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_SpecialitzationOfDoctorId",
                table: "AspNetUsers",
                column: "SpecialitzationOfDoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Clinics_Doctor_ClinicId",
                table: "AspNetUsers",
                column: "Doctor_ClinicId",
                principalTable: "Clinics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_SpecializationOfDoctors_SpecialitzationOfDoctorId",
                table: "AspNetUsers",
                column: "SpecialitzationOfDoctorId",
                principalTable: "SpecializationOfDoctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_AspNetUsers_DoctorId1",
                table: "Visits",
                column: "DoctorId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_AspNetUsers_DoctorId3",
                table: "Visits",
                column: "DoctorId3",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Clinics_Doctor_ClinicId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_SpecializationOfDoctors_SpecialitzationOfDoctorId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Visits_AspNetUsers_DoctorId1",
                table: "Visits");

            migrationBuilder.DropForeignKey(
                name: "FK_Visits_AspNetUsers_DoctorId3",
                table: "Visits");

            migrationBuilder.DropIndex(
                name: "IX_Visits_DoctorId1",
                table: "Visits");

            migrationBuilder.DropIndex(
                name: "IX_Visits_DoctorId3",
                table: "Visits");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_Doctor_ClinicId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_SpecialitzationOfDoctorId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DoctorId1",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "DoctorId3",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "Doctor_Adnotations",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Doctor_ClinicId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Doctor_DateOfBirth",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Doctor_DateOfCreation",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Doctor_DateOfModification",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Doctor_FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Doctor_IsPatient",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Doctor_LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Doctor_OwnPicture",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Doctor_Pesel",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Doctor_RoleOfUser",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Doctor_Sex",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Doctor_SpecializationId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Doctor_isActivate",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Doctor_isDoctor",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SpecialitzationOfDoctorId",
                table: "AspNetUsers");
        }
    }
}

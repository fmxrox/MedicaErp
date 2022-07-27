using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.MedicaERPMVC.Migrations
{
    public partial class _2607 : Migration
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
                name: "FK_Visits_AspNetUsers_PatientNameId",
                table: "Visits");

            migrationBuilder.DropIndex(
                name: "IX_Visits_PatientNameId",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "PatientNameId",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Visits");

            migrationBuilder.RenameColumn(
                name: "SpecialitzationOfDoctorId",
                table: "AspNetUsers",
                newName: "SpecializationId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_SpecialitzationOfDoctorId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_SpecializationId");

            migrationBuilder.AddColumn<string>(
                name: "DoctorId",
                table: "Visits",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PatientId",
                table: "Visits",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Visits_DoctorId",
                table: "Visits",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Visits_PatientId",
                table: "Visits",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Clinics_ClinicId",
                table: "AspNetUsers",
                column: "ClinicId",
                principalTable: "Clinics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_SpecializationOfDoctors_SpecializationId",
                table: "AspNetUsers",
                column: "SpecializationId",
                principalTable: "SpecializationOfDoctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_AspNetUsers_DoctorId",
                table: "Visits",
                column: "DoctorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_AspNetUsers_PatientId",
                table: "Visits",
                column: "PatientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Clinics_ClinicId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_SpecializationOfDoctors_SpecializationId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Visits_AspNetUsers_DoctorId",
                table: "Visits");

            migrationBuilder.DropForeignKey(
                name: "FK_Visits_AspNetUsers_PatientId",
                table: "Visits");

            migrationBuilder.DropIndex(
                name: "IX_Visits_DoctorId",
                table: "Visits");

            migrationBuilder.DropIndex(
                name: "IX_Visits_PatientId",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "Visits");

            migrationBuilder.RenameColumn(
                name: "SpecializationId",
                table: "AspNetUsers",
                newName: "SpecialitzationOfDoctorId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_SpecializationId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_SpecialitzationOfDoctorId");

            migrationBuilder.AddColumn<string>(
                name: "PatientNameId",
                table: "Visits",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Visits",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Visits_PatientNameId",
                table: "Visits",
                column: "PatientNameId");

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
                name: "FK_Visits_AspNetUsers_PatientNameId",
                table: "Visits",
                column: "PatientNameId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.MedicaERPMVC.Migrations
{
    public partial class UserToClinic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClinicId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ClinicId",
                table: "AspNetUsers",
                column: "ClinicId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Clinics_ClinicId",
                table: "AspNetUsers",
                column: "ClinicId",
                principalTable: "Clinics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Clinics_ClinicId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ClinicId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ClinicId",
                table: "AspNetUsers");
        }
    }
}

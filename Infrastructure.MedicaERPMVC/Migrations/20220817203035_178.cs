using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.MedicaERPMVC.Migrations
{
    public partial class _178 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isMedic",
                table: "AspNetUsers",
                newName: "isDoctor");

            migrationBuilder.AddColumn<bool>(
                name: "IsPatient",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPatient",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "isDoctor",
                table: "AspNetUsers",
                newName: "isMedic");
        }
    }
}

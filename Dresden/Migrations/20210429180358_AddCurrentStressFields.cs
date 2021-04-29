using Microsoft.EntityFrameworkCore.Migrations;

namespace Dresden.Migrations
{
    public partial class AddCurrentStressFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MentalStressTaken",
                table: "Characters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PhysicalStressTaken",
                table: "Characters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RefreshUsed",
                table: "Characters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SocialStressTaken",
                table: "Characters",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MentalStressTaken",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "PhysicalStressTaken",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "RefreshUsed",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "SocialStressTaken",
                table: "Characters");
        }
    }
}

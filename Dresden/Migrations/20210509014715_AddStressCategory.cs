using Microsoft.EntityFrameworkCore.Migrations;

namespace Dresden.Migrations
{
    public partial class AddStressCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StressCategory",
                table: "Consequences",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StressCategory",
                table: "Consequences");
        }
    }
}

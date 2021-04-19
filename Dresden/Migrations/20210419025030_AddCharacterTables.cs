using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dresden.Migrations
{
    public partial class AddCharacterTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DeleteUtc",
                table: "Trappings",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LastUpdateUtc",
                table: "Trappings",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DeleteUtc",
                table: "Stunts",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LastUpdateUtc",
                table: "Stunts",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RefreshCost",
                table: "Stunts",
                type: "int",
                nullable: false,
                defaultValue: -1);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DeleteUtc",
                table: "Skills",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdateUtc",
                table: "Skills",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdateUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeleteUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CharacterVersions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CharacterId = table.Column<int>(type: "int", nullable: false),
                    PhysicalStressBoxes = table.Column<int>(type: "int", nullable: false),
                    MentalStressBoxes = table.Column<int>(type: "int", nullable: false),
                    SocialStressBoxes = table.Column<int>(type: "int", nullable: false),
                    BaseReferesh = table.Column<int>(type: "int", nullable: false),
                    CreateUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DeleteUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterVersions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharacterVersions_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Consequences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CharacterId = table.Column<int>(type: "int", nullable: false),
                    StressAmount = table.Column<int>(type: "int", nullable: false),
                    Aspect = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DeleteUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consequences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Consequences_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TemporaryAspects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CharacterId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DeleteUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemporaryAspects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TemporaryAspects_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterAspects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CharacterVersionId = table.Column<int>(type: "int", nullable: false),
                    AspectType = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DeleteUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterAspects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharacterAspects_CharacterVersions_CharacterVersionId",
                        column: x => x.CharacterVersionId,
                        principalTable: "CharacterVersions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterSkills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CharacterVersionId = table.Column<int>(type: "int", nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: false),
                    SkillLevel = table.Column<int>(type: "int", nullable: false),
                    CreateUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DeleteUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterSkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharacterSkills_CharacterVersions_CharacterVersionId",
                        column: x => x.CharacterVersionId,
                        principalTable: "CharacterVersions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterStunts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CharacterVersionId = table.Column<int>(type: "int", nullable: false),
                    StuntId = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DeleteUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterStunts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharacterStunts_CharacterVersions_CharacterVersionId",
                        column: x => x.CharacterVersionId,
                        principalTable: "CharacterVersions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterStunts_Stunts_StuntId",
                        column: x => x.StuntId,
                        principalTable: "Stunts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterAspects_CharacterVersionId",
                table: "CharacterAspects",
                column: "CharacterVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterSkills_CharacterVersionId",
                table: "CharacterSkills",
                column: "CharacterVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterSkills_SkillId",
                table: "CharacterSkills",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterStunts_CharacterVersionId",
                table: "CharacterStunts",
                column: "CharacterVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterStunts_StuntId",
                table: "CharacterStunts",
                column: "StuntId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterVersions_CharacterId",
                table: "CharacterVersions",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Consequences_CharacterId",
                table: "Consequences",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_TemporaryAspects_CharacterId",
                table: "TemporaryAspects",
                column: "CharacterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterAspects");

            migrationBuilder.DropTable(
                name: "CharacterSkills");

            migrationBuilder.DropTable(
                name: "CharacterStunts");

            migrationBuilder.DropTable(
                name: "Consequences");

            migrationBuilder.DropTable(
                name: "TemporaryAspects");

            migrationBuilder.DropTable(
                name: "CharacterVersions");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropColumn(
                name: "DeleteUtc",
                table: "Trappings");

            migrationBuilder.DropColumn(
                name: "LastUpdateUtc",
                table: "Trappings");

            migrationBuilder.DropColumn(
                name: "DeleteUtc",
                table: "Stunts");

            migrationBuilder.DropColumn(
                name: "LastUpdateUtc",
                table: "Stunts");

            migrationBuilder.DropColumn(
                name: "RefreshCost",
                table: "Stunts");

            migrationBuilder.DropColumn(
                name: "DeleteUtc",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "UpdateUtc",
                table: "Skills");
        }
    }
}

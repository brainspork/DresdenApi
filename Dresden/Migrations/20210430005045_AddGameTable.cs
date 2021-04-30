using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dresden.Migrations
{
    public partial class AddGameTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterAspects_CharacterVersions_CharacterVersionId",
                table: "CharacterAspects");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Users_UserId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterSkills_CharacterVersions_CharacterVersionId",
                table: "CharacterSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterSkills_Skills_SkillId",
                table: "CharacterSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterStunts_CharacterVersions_CharacterVersionId",
                table: "CharacterStunts");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterStunts_Stunts_StuntId",
                table: "CharacterStunts");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterVersions_Characters_CharacterId",
                table: "CharacterVersions");

            migrationBuilder.DropForeignKey(
                name: "FK_Consequences_Characters_CharacterId",
                table: "Consequences");

            migrationBuilder.DropForeignKey(
                name: "FK_Stunts_Skills_SkillId",
                table: "Stunts");

            migrationBuilder.DropForeignKey(
                name: "FK_TemporaryAspects_Characters_CharacterId",
                table: "TemporaryAspects");

            migrationBuilder.DropForeignKey(
                name: "FK_Trappings_Skills_SkillId",
                table: "Trappings");

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameManagerId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_Users_GameManagerId",
                        column: x => x.GameManagerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GameNonPlayerCharacter",
                columns: table => new
                {
                    CharacterId = table.Column<int>(type: "int", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameNonPlayerCharacter", x => new { x.CharacterId, x.GameId });
                    table.ForeignKey(
                        name: "FK_GameNonPlayerCharacter_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GameNonPlayerCharacter_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GamePlayerCharacter",
                columns: table => new
                {
                    CharacterId = table.Column<int>(type: "int", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamePlayerCharacter", x => new { x.CharacterId, x.GameId });
                    table.ForeignKey(
                        name: "FK_GamePlayerCharacter_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GamePlayerCharacter_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameNonPlayerCharacter_GameId",
                table: "GameNonPlayerCharacter",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_GamePlayerCharacter_GameId",
                table: "GamePlayerCharacter",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_GameManagerId",
                table: "Games",
                column: "GameManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterAspects_CharacterVersions_CharacterVersionId",
                table: "CharacterAspects",
                column: "CharacterVersionId",
                principalTable: "CharacterVersions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Users_UserId",
                table: "Characters",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterSkills_CharacterVersions_CharacterVersionId",
                table: "CharacterSkills",
                column: "CharacterVersionId",
                principalTable: "CharacterVersions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterSkills_Skills_SkillId",
                table: "CharacterSkills",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterStunts_CharacterVersions_CharacterVersionId",
                table: "CharacterStunts",
                column: "CharacterVersionId",
                principalTable: "CharacterVersions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterStunts_Stunts_StuntId",
                table: "CharacterStunts",
                column: "StuntId",
                principalTable: "Stunts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterVersions_Characters_CharacterId",
                table: "CharacterVersions",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Consequences_Characters_CharacterId",
                table: "Consequences",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Stunts_Skills_SkillId",
                table: "Stunts",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TemporaryAspects_Characters_CharacterId",
                table: "TemporaryAspects",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Trappings_Skills_SkillId",
                table: "Trappings",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterAspects_CharacterVersions_CharacterVersionId",
                table: "CharacterAspects");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Users_UserId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterSkills_CharacterVersions_CharacterVersionId",
                table: "CharacterSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterSkills_Skills_SkillId",
                table: "CharacterSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterStunts_CharacterVersions_CharacterVersionId",
                table: "CharacterStunts");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterStunts_Stunts_StuntId",
                table: "CharacterStunts");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterVersions_Characters_CharacterId",
                table: "CharacterVersions");

            migrationBuilder.DropForeignKey(
                name: "FK_Consequences_Characters_CharacterId",
                table: "Consequences");

            migrationBuilder.DropForeignKey(
                name: "FK_Stunts_Skills_SkillId",
                table: "Stunts");

            migrationBuilder.DropForeignKey(
                name: "FK_TemporaryAspects_Characters_CharacterId",
                table: "TemporaryAspects");

            migrationBuilder.DropForeignKey(
                name: "FK_Trappings_Skills_SkillId",
                table: "Trappings");

            migrationBuilder.DropTable(
                name: "GameNonPlayerCharacter");

            migrationBuilder.DropTable(
                name: "GamePlayerCharacter");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterAspects_CharacterVersions_CharacterVersionId",
                table: "CharacterAspects",
                column: "CharacterVersionId",
                principalTable: "CharacterVersions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Users_UserId",
                table: "Characters",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterSkills_CharacterVersions_CharacterVersionId",
                table: "CharacterSkills",
                column: "CharacterVersionId",
                principalTable: "CharacterVersions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterSkills_Skills_SkillId",
                table: "CharacterSkills",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterStunts_CharacterVersions_CharacterVersionId",
                table: "CharacterStunts",
                column: "CharacterVersionId",
                principalTable: "CharacterVersions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterStunts_Stunts_StuntId",
                table: "CharacterStunts",
                column: "StuntId",
                principalTable: "Stunts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterVersions_Characters_CharacterId",
                table: "CharacterVersions",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Consequences_Characters_CharacterId",
                table: "Consequences",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stunts_Skills_SkillId",
                table: "Stunts",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TemporaryAspects_Characters_CharacterId",
                table: "TemporaryAspects",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trappings_Skills_SkillId",
                table: "Trappings",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

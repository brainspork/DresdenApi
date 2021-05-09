using Microsoft.EntityFrameworkCore.Migrations;

namespace Dresden.Migrations
{
    public partial class ChangeStressToEnum : Migration
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
                name: "FK_Games_Users_GameManagerId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Stunts_Skills_SkillId",
                table: "Stunts");

            migrationBuilder.DropForeignKey(
                name: "FK_TemporaryAspects_Characters_CharacterId",
                table: "TemporaryAspects");

            migrationBuilder.DropForeignKey(
                name: "FK_Trappings_Skills_SkillId",
                table: "Trappings");

            migrationBuilder.RenameColumn(
                name: "StressAmount",
                table: "Consequences",
                newName: "StressType");

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
                name: "FK_Games_Users_GameManagerId",
                table: "Games",
                column: "GameManagerId",
                principalTable: "Users",
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
                name: "FK_Games_Users_GameManagerId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Stunts_Skills_SkillId",
                table: "Stunts");

            migrationBuilder.DropForeignKey(
                name: "FK_TemporaryAspects_Characters_CharacterId",
                table: "TemporaryAspects");

            migrationBuilder.DropForeignKey(
                name: "FK_Trappings_Skills_SkillId",
                table: "Trappings");

            migrationBuilder.RenameColumn(
                name: "StressType",
                table: "Consequences",
                newName: "StressAmount");

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
                name: "FK_Games_Users_GameManagerId",
                table: "Games",
                column: "GameManagerId",
                principalTable: "Users",
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
    }
}

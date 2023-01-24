using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlayerBaseApi.Migrations
{
    public partial class tutorialquestchangedbuffadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "TutorialQuest",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "WarHeroExpMultiplier",
                table: "Buff",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "WarLootMultiplier",
                table: "Buff",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_TutorialQuest_ParentId",
                table: "TutorialQuest",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_TutorialQuest_TutorialQuest_ParentId",
                table: "TutorialQuest",
                column: "ParentId",
                principalTable: "TutorialQuest",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TutorialQuest_TutorialQuest_ParentId",
                table: "TutorialQuest");

            migrationBuilder.DropIndex(
                name: "IX_TutorialQuest_ParentId",
                table: "TutorialQuest");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "TutorialQuest");

            migrationBuilder.DropColumn(
                name: "WarHeroExpMultiplier",
                table: "Buff");

            migrationBuilder.DropColumn(
                name: "WarLootMultiplier",
                table: "Buff");
        }
    }
}

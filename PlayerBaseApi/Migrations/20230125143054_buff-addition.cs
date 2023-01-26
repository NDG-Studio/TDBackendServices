using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlayerBaseApi.Migrations
{
    public partial class buffaddition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AfterActiveSkillTroopDamageWithSecond",
                table: "Buff",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AfterActiveSkillTroopDefenseWithSecond",
                table: "Buff",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "AfterWinningTroopMarchSpeed",
                table: "Buff",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "AllTowerRangeMultiplier",
                table: "Buff",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "EnemyGangTroopDamageMultiplier",
                table: "Buff",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "EnemyGangTroopDefenseMultiplier",
                table: "Buff",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "EnemyHeroDamageMultiplier",
                table: "Buff",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "EnemyHeroDefenseMultiplier",
                table: "Buff",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "EnemyTroopDefenseMultiplier",
                table: "Buff",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "HeroFirstSecondDamageToEnemy",
                table: "Buff",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HeroFirstSecondDamageToNeutral",
                table: "Buff",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HeroFirstSecondDefenseToEnemy",
                table: "Buff",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HeroFirstSecondDefenseToNeutral",
                table: "Buff",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "HeroLevelHpMultiplier",
                table: "Buff",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "HeroLevelSpeedMultiplier",
                table: "Buff",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TroopCountMultiplier",
                table: "Buff",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "TroopFirstSecondDamageToEnemy",
                table: "Buff",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TroopFirstSecondDamageToNeutral",
                table: "Buff",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TroopFirstSecondDefenseToEnemy",
                table: "Buff",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TroopFirstSecondDefenseToNeutral",
                table: "Buff",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AfterActiveSkillTroopDamageWithSecond",
                table: "Buff");

            migrationBuilder.DropColumn(
                name: "AfterActiveSkillTroopDefenseWithSecond",
                table: "Buff");

            migrationBuilder.DropColumn(
                name: "AfterWinningTroopMarchSpeed",
                table: "Buff");

            migrationBuilder.DropColumn(
                name: "AllTowerRangeMultiplier",
                table: "Buff");

            migrationBuilder.DropColumn(
                name: "EnemyGangTroopDamageMultiplier",
                table: "Buff");

            migrationBuilder.DropColumn(
                name: "EnemyGangTroopDefenseMultiplier",
                table: "Buff");

            migrationBuilder.DropColumn(
                name: "EnemyHeroDamageMultiplier",
                table: "Buff");

            migrationBuilder.DropColumn(
                name: "EnemyHeroDefenseMultiplier",
                table: "Buff");

            migrationBuilder.DropColumn(
                name: "EnemyTroopDefenseMultiplier",
                table: "Buff");

            migrationBuilder.DropColumn(
                name: "HeroFirstSecondDamageToEnemy",
                table: "Buff");

            migrationBuilder.DropColumn(
                name: "HeroFirstSecondDamageToNeutral",
                table: "Buff");

            migrationBuilder.DropColumn(
                name: "HeroFirstSecondDefenseToEnemy",
                table: "Buff");

            migrationBuilder.DropColumn(
                name: "HeroFirstSecondDefenseToNeutral",
                table: "Buff");

            migrationBuilder.DropColumn(
                name: "HeroLevelHpMultiplier",
                table: "Buff");

            migrationBuilder.DropColumn(
                name: "HeroLevelSpeedMultiplier",
                table: "Buff");

            migrationBuilder.DropColumn(
                name: "TroopCountMultiplier",
                table: "Buff");

            migrationBuilder.DropColumn(
                name: "TroopFirstSecondDamageToEnemy",
                table: "Buff");

            migrationBuilder.DropColumn(
                name: "TroopFirstSecondDamageToNeutral",
                table: "Buff");

            migrationBuilder.DropColumn(
                name: "TroopFirstSecondDefenseToEnemy",
                table: "Buff");

            migrationBuilder.DropColumn(
                name: "TroopFirstSecondDefenseToNeutral",
                table: "Buff");
        }
    }
}

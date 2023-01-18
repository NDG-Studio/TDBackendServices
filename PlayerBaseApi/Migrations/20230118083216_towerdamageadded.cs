using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlayerBaseApi.Migrations
{
    public partial class towerdamageadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LootRunDurationMultiplier",
                table: "Buff",
                newName: "TowerDamageMultiplier");

            migrationBuilder.RenameColumn(
                name: "LootRunCapacityMultiplier",
                table: "Buff",
                newName: "TowerAttackSpeedMultiplier");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TowerDamageMultiplier",
                table: "Buff",
                newName: "LootRunDurationMultiplier");

            migrationBuilder.RenameColumn(
                name: "TowerAttackSpeedMultiplier",
                table: "Buff",
                newName: "LootRunCapacityMultiplier");
        }
    }
}

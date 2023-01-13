using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlayerBaseApi.Migrations
{
    public partial class buffsandquests : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StageId",
                table: "TutorialQuest");

            migrationBuilder.RenameColumn(
                name: "StageOrderId",
                table: "TutorialQuest",
                newName: "OrderId");

            migrationBuilder.RenameColumn(
                name: "TroopCapacityMultiplier",
                table: "Buff",
                newName: "TroopScrapCapacityMultiplier");

            migrationBuilder.RenameColumn(
                name: "FirstTime",
                table: "Buff",
                newName: "GangMemberCapacity");

            migrationBuilder.RenameColumn(
                name: "DamageWithTime",
                table: "Buff",
                newName: "SupportUnitTroopCapacity");

            migrationBuilder.AlterColumn<int>(
                name: "TowerLevel",
                table: "Buff",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "TowerId",
                table: "Buff",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<double>(
                name: "BarrackTroopCapacity",
                table: "Buff",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "BaseTroopPower",
                table: "Buff",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "FirstTimeDamage",
                table: "Buff",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Buff",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "TowerId", "TowerLevel" },
                values: new object[] { null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BarrackTroopCapacity",
                table: "Buff");

            migrationBuilder.DropColumn(
                name: "BaseTroopPower",
                table: "Buff");

            migrationBuilder.DropColumn(
                name: "FirstTimeDamage",
                table: "Buff");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "TutorialQuest",
                newName: "StageOrderId");

            migrationBuilder.RenameColumn(
                name: "TroopScrapCapacityMultiplier",
                table: "Buff",
                newName: "TroopCapacityMultiplier");

            migrationBuilder.RenameColumn(
                name: "SupportUnitTroopCapacity",
                table: "Buff",
                newName: "DamageWithTime");

            migrationBuilder.RenameColumn(
                name: "GangMemberCapacity",
                table: "Buff",
                newName: "FirstTime");

            migrationBuilder.AddColumn<int>(
                name: "StageId",
                table: "TutorialQuest",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "TowerLevel",
                table: "Buff",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TowerId",
                table: "Buff",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Buff",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "TowerId", "TowerLevel" },
                values: new object[] { 0, 0 });
        }
    }
}

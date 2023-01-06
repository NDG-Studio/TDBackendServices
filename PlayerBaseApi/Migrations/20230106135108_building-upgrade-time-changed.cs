using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlayerBaseApi.Migrations
{
    public partial class buildingupgradetimechanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BuffId",
                table: "BuildingUpgradeTime",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "BuildingUpgradeTime",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Power",
                table: "BuildingUpgradeTime",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BuildingUpgradeTime_BuffId",
                table: "BuildingUpgradeTime",
                column: "BuffId");

            migrationBuilder.AddForeignKey(
                name: "FK_BuildingUpgradeTime_Buff_BuffId",
                table: "BuildingUpgradeTime",
                column: "BuffId",
                principalTable: "Buff",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BuildingUpgradeTime_Buff_BuffId",
                table: "BuildingUpgradeTime");

            migrationBuilder.DropIndex(
                name: "IX_BuildingUpgradeTime_BuffId",
                table: "BuildingUpgradeTime");

            migrationBuilder.DropColumn(
                name: "BuffId",
                table: "BuildingUpgradeTime");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "BuildingUpgradeTime");

            migrationBuilder.DropColumn(
                name: "Power",
                table: "BuildingUpgradeTime");
        }
    }
}

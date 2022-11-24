using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlayerBaseApi.Migrations
{
    public partial class BuildingUpgradeConditiontypofixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BuildingUpgradeCondition_BuildingType_BuildingTypeId",
                table: "BuildingUpgradeCondition");

            migrationBuilder.DropIndex(
                name: "IX_BuildingUpgradeCondition_BuildingTypeId",
                table: "BuildingUpgradeCondition");

            migrationBuilder.DropColumn(
                name: "BuildingTypeId",
                table: "BuildingUpgradeCondition");

            migrationBuilder.CreateIndex(
                name: "IX_BuildingUpgradeCondition_BuildingId",
                table: "BuildingUpgradeCondition",
                column: "BuildingId");

            migrationBuilder.AddForeignKey(
                name: "FK_BuildingUpgradeCondition_BuildingType_BuildingId",
                table: "BuildingUpgradeCondition",
                column: "BuildingId",
                principalTable: "BuildingType",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BuildingUpgradeCondition_BuildingType_BuildingId",
                table: "BuildingUpgradeCondition");

            migrationBuilder.DropIndex(
                name: "IX_BuildingUpgradeCondition_BuildingId",
                table: "BuildingUpgradeCondition");

            migrationBuilder.AddColumn<int>(
                name: "BuildingTypeId",
                table: "BuildingUpgradeCondition",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BuildingUpgradeCondition_BuildingTypeId",
                table: "BuildingUpgradeCondition",
                column: "BuildingTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_BuildingUpgradeCondition_BuildingType_BuildingTypeId",
                table: "BuildingUpgradeCondition",
                column: "BuildingTypeId",
                principalTable: "BuildingType",
                principalColumn: "Id");
        }
    }
}

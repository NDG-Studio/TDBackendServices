using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZTD.Migrations
{
    public partial class researchconditionbugfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResearchNodeUpgradeCondition_ResearchNode_ResearchNodeId",
                table: "ResearchNodeUpgradeCondition");

            migrationBuilder.DropForeignKey(
                name: "FK_ResearchNodeUpgradeCondition_ResearchNodeLevel_ResearchNode~",
                table: "ResearchNodeUpgradeCondition");

            migrationBuilder.RenameColumn(
                name: "ResearchNodeId",
                table: "ResearchNodeUpgradeCondition",
                newName: "PrereqResearchNodeId");

            migrationBuilder.RenameIndex(
                name: "IX_ResearchNodeUpgradeCondition_ResearchNodeId",
                table: "ResearchNodeUpgradeCondition",
                newName: "IX_ResearchNodeUpgradeCondition_PrereqResearchNodeId");

            migrationBuilder.AlterColumn<int>(
                name: "ResearchNodeLevelId",
                table: "ResearchNodeUpgradeCondition",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "FirstLogInDate", "LastSeen" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 2, 14, 11, 55, 6, 978, DateTimeKind.Unspecified).AddTicks(1170), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 2, 14, 11, 55, 6, 978, DateTimeKind.Unspecified).AddTicks(1220), new TimeSpan(0, 3, 0, 0, 0)) });

            migrationBuilder.AddForeignKey(
                name: "FK_ResearchNodeUpgradeCondition_ResearchNode_PrereqResearchNod~",
                table: "ResearchNodeUpgradeCondition",
                column: "PrereqResearchNodeId",
                principalTable: "ResearchNode",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResearchNodeUpgradeCondition_ResearchNodeLevel_ResearchNode~",
                table: "ResearchNodeUpgradeCondition",
                column: "ResearchNodeLevelId",
                principalTable: "ResearchNodeLevel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResearchNodeUpgradeCondition_ResearchNode_PrereqResearchNod~",
                table: "ResearchNodeUpgradeCondition");

            migrationBuilder.DropForeignKey(
                name: "FK_ResearchNodeUpgradeCondition_ResearchNodeLevel_ResearchNode~",
                table: "ResearchNodeUpgradeCondition");

            migrationBuilder.RenameColumn(
                name: "PrereqResearchNodeId",
                table: "ResearchNodeUpgradeCondition",
                newName: "ResearchNodeId");

            migrationBuilder.RenameIndex(
                name: "IX_ResearchNodeUpgradeCondition_PrereqResearchNodeId",
                table: "ResearchNodeUpgradeCondition",
                newName: "IX_ResearchNodeUpgradeCondition_ResearchNodeId");

            migrationBuilder.AlterColumn<int>(
                name: "ResearchNodeLevelId",
                table: "ResearchNodeUpgradeCondition",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "FirstLogInDate", "LastSeen" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 2, 13, 18, 31, 57, 576, DateTimeKind.Unspecified).AddTicks(5430), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 2, 13, 18, 31, 57, 576, DateTimeKind.Unspecified).AddTicks(5490), new TimeSpan(0, 3, 0, 0, 0)) });

            migrationBuilder.AddForeignKey(
                name: "FK_ResearchNodeUpgradeCondition_ResearchNode_ResearchNodeId",
                table: "ResearchNodeUpgradeCondition",
                column: "ResearchNodeId",
                principalTable: "ResearchNode",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResearchNodeUpgradeCondition_ResearchNodeLevel_ResearchNode~",
                table: "ResearchNodeUpgradeCondition",
                column: "ResearchNodeLevelId",
                principalTable: "ResearchNodeLevel",
                principalColumn: "Id");
        }
    }
}

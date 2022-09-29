using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PlayerBaseApi.Migrations
{
    public partial class researchnodeupgradeconditionadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ResearchNodeUpgradeCondition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ResearchNodeUpgradeNecessariesId = table.Column<int>(type: "integer", nullable: false),
                    ResearchNodeId = table.Column<int>(type: "integer", nullable: true),
                    BuildingTypeId = table.Column<int>(type: "integer", nullable: true),
                    PrereqLevel = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResearchNodeUpgradeCondition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResearchNodeUpgradeCondition_BuildingType_BuildingTypeId",
                        column: x => x.BuildingTypeId,
                        principalTable: "BuildingType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ResearchNodeUpgradeCondition_ResearchNode_ResearchNodeId",
                        column: x => x.ResearchNodeId,
                        principalTable: "ResearchNode",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ResearchNodeUpgradeCondition_ResearchNodeUpgradeNecessaries~",
                        column: x => x.ResearchNodeUpgradeNecessariesId,
                        principalTable: "ResearchNodeUpgradeNecessaries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ResearchNodeUpgradeCondition_BuildingTypeId",
                table: "ResearchNodeUpgradeCondition",
                column: "BuildingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ResearchNodeUpgradeCondition_ResearchNodeId",
                table: "ResearchNodeUpgradeCondition",
                column: "ResearchNodeId");

            migrationBuilder.CreateIndex(
                name: "IX_ResearchNodeUpgradeCondition_ResearchNodeUpgradeNecessaries~",
                table: "ResearchNodeUpgradeCondition",
                column: "ResearchNodeUpgradeNecessariesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResearchNodeUpgradeCondition");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PlayerBaseApi.Migrations
{
    public partial class conditionsadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BuildingUpgradeCondition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BuildingId = table.Column<int>(type: "integer", nullable: true),
                    BuildingLevel = table.Column<int>(type: "integer", nullable: true),
                    PrereqBuildingTypeId = table.Column<int>(type: "integer", nullable: true),
                    PrereqLevel = table.Column<int>(type: "integer", nullable: false),
                    BuildingTypeId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingUpgradeCondition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuildingUpgradeCondition_BuildingType_BuildingTypeId",
                        column: x => x.BuildingTypeId,
                        principalTable: "BuildingType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BuildingUpgradeCondition_BuildingType_PrereqBuildingTypeId",
                        column: x => x.PrereqBuildingTypeId,
                        principalTable: "BuildingType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BuildingUpgradeCondition_BuildingTypeId",
                table: "BuildingUpgradeCondition",
                column: "BuildingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildingUpgradeCondition_PrereqBuildingTypeId",
                table: "BuildingUpgradeCondition",
                column: "PrereqBuildingTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuildingUpgradeCondition");
        }
    }
}

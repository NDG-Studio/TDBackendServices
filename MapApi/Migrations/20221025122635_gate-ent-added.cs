using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MapApi.Migrations
{
    public partial class gateentadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TroopCount = table.Column<int>(type: "integer", nullable: false),
                    GangId = table.Column<int>(type: "integer", nullable: false),
                    GateStateId = table.Column<int>(type: "integer", nullable: false),
                    PassPricePerUnit = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gate", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MapItem_GateId",
                table: "MapItem",
                column: "GateId");

            migrationBuilder.AddForeignKey(
                name: "FK_MapItem_Gate_GateId",
                table: "MapItem",
                column: "GateId",
                principalTable: "Gate",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MapItem_Gate_GateId",
                table: "MapItem");

            migrationBuilder.DropTable(
                name: "Gate");

            migrationBuilder.DropIndex(
                name: "IX_MapItem_GateId",
                table: "MapItem");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PlayerBaseApi.Migrations
{
    public partial class researchtablefix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlaceId",
                table: "ResearchNode",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PlayerResearchNode",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    ResearchNodeId = table.Column<int>(type: "integer", nullable: false),
                    CurrentLevel = table.Column<int>(type: "integer", nullable: false),
                    UpdateEndDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerResearchNode", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerResearchNode_ResearchNode_ResearchNodeId",
                        column: x => x.ResearchNodeId,
                        principalTable: "ResearchNode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "ResearchNode",
                keyColumn: "Id",
                keyValue: 1,
                column: "PlaceId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ResearchNode",
                keyColumn: "Id",
                keyValue: 2,
                column: "PlaceId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ResearchNode",
                keyColumn: "Id",
                keyValue: 3,
                column: "PlaceId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "ResearchNode",
                keyColumn: "Id",
                keyValue: 4,
                column: "PlaceId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "ResearchNode",
                keyColumn: "Id",
                keyValue: 5,
                column: "PlaceId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "ResearchNode",
                keyColumn: "Id",
                keyValue: 6,
                column: "PlaceId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ResearchNode",
                keyColumn: "Id",
                keyValue: 7,
                column: "PlaceId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ResearchNode",
                keyColumn: "Id",
                keyValue: 8,
                column: "PlaceId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "ResearchNode",
                keyColumn: "Id",
                keyValue: 9,
                column: "PlaceId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "ResearchNode",
                keyColumn: "Id",
                keyValue: 10,
                column: "PlaceId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "ResearchNode",
                keyColumn: "Id",
                keyValue: 11,
                column: "PlaceId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ResearchNode",
                keyColumn: "Id",
                keyValue: 12,
                column: "PlaceId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ResearchNode",
                keyColumn: "Id",
                keyValue: 13,
                column: "PlaceId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "ResearchNode",
                keyColumn: "Id",
                keyValue: 14,
                column: "PlaceId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "ResearchNode",
                keyColumn: "Id",
                keyValue: 15,
                column: "PlaceId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "ResearchNode",
                keyColumn: "Id",
                keyValue: 16,
                column: "PlaceId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ResearchNode",
                keyColumn: "Id",
                keyValue: 17,
                column: "PlaceId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ResearchNode",
                keyColumn: "Id",
                keyValue: 18,
                column: "PlaceId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "ResearchNode",
                keyColumn: "Id",
                keyValue: 19,
                column: "PlaceId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "ResearchNode",
                keyColumn: "Id",
                keyValue: 20,
                column: "PlaceId",
                value: 5);

            migrationBuilder.CreateIndex(
                name: "IX_PlayerResearchNode_ResearchNodeId",
                table: "PlayerResearchNode",
                column: "ResearchNodeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerResearchNode");

            migrationBuilder.DropColumn(
                name: "PlaceId",
                table: "ResearchNode");
        }
    }
}

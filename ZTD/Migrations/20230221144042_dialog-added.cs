using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ZTD.Migrations
{
    public partial class dialogadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DialogScene",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DialogScene", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dialog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HeroId = table.Column<int>(type: "integer", nullable: false),
                    DialogSceneId = table.Column<int>(type: "integer", nullable: false),
                    AnimId = table.Column<string>(type: "text", nullable: false),
                    TypeName = table.Column<string>(type: "text", nullable: false),
                    PlaceId = table.Column<int>(type: "integer", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dialog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dialog_DialogScene_DialogSceneId",
                        column: x => x.DialogSceneId,
                        principalTable: "DialogScene",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "FirstLogInDate", "LastSeen" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 2, 21, 17, 40, 42, 173, DateTimeKind.Unspecified).AddTicks(2610), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 2, 21, 17, 40, 42, 173, DateTimeKind.Unspecified).AddTicks(2670), new TimeSpan(0, 3, 0, 0, 0)) });

            migrationBuilder.CreateIndex(
                name: "IX_Dialog_DialogSceneId",
                table: "Dialog",
                column: "DialogSceneId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dialog");

            migrationBuilder.DropTable(
                name: "DialogScene");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "FirstLogInDate", "LastSeen" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 2, 16, 15, 12, 20, 248, DateTimeKind.Unspecified).AddTicks(7320), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 2, 16, 15, 12, 20, 248, DateTimeKind.Unspecified).AddTicks(7360), new TimeSpan(0, 3, 0, 0, 0)) });
        }
    }
}

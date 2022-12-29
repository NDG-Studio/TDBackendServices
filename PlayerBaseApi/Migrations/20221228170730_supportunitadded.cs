using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PlayerBaseApi.Migrations
{
    public partial class supportunitadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SupportUnit",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HostUserId = table.Column<long>(type: "bigint", nullable: false),
                    ClientUserId = table.Column<long>(type: "bigint", nullable: false),
                    HeroId = table.Column<int>(type: "integer", nullable: false),
                    TroopCount = table.Column<int>(type: "integer", nullable: false),
                    Wounded = table.Column<int>(type: "integer", nullable: false),
                    Dead = table.Column<int>(type: "integer", nullable: false),
                    ArrivedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    ComeBackDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    SendedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    State = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupportUnit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupportUnit_Hero_HeroId",
                        column: x => x.HeroId,
                        principalTable: "Hero",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SupportUnit_HeroId",
                table: "SupportUnit",
                column: "HeroId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SupportUnit");
        }
    }
}

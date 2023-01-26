using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebSocket.Migrations
{
    public partial class donationhistoryadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DonationHistory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    ScrapCount = table.Column<int>(type: "integer", nullable: false),
                    GangId = table.Column<Guid>(type: "uuid", nullable: false),
                    DonationDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    IsSuccess = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonationHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DonationHistory_Gang_GangId",
                        column: x => x.GangId,
                        principalTable: "Gang",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DonationHistory_GangId",
                table: "DonationHistory",
                column: "GangId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DonationHistory");
        }
    }
}

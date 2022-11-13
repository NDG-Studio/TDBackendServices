using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebSocket.Migrations
{
    public partial class gangentitiesadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gang",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    OwnerId = table.Column<long>(type: "bigint", nullable: false),
                    OwnerName = table.Column<string>(type: "text", nullable: false),
                    ScrapPool = table.Column<long>(type: "bigint", nullable: false),
                    Level = table.Column<int>(type: "integer", nullable: false),
                    Capacity = table.Column<int>(type: "integer", nullable: false),
                    RaidCapacity = table.Column<int>(type: "integer", nullable: false),
                    Power = table.Column<long>(type: "bigint", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gang", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MemberType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CanMemberChangeType = table.Column<bool>(type: "boolean", nullable: false),
                    CanKick = table.Column<bool>(type: "boolean", nullable: false),
                    CanStartWar = table.Column<bool>(type: "boolean", nullable: false),
                    GateManager = table.Column<bool>(type: "boolean", nullable: false),
                    CanDistributeMoney = table.Column<bool>(type: "boolean", nullable: false),
                    CanAcceptMember = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    GangId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MemberType_Gang_GangId",
                        column: x => x.GangId,
                        principalTable: "Gang",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GangMember",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    MemberTypeId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GangMember", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GangMember_MemberType_MemberTypeId",
                        column: x => x.MemberTypeId,
                        principalTable: "MemberType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GangMember_MemberTypeId",
                table: "GangMember",
                column: "MemberTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberType_GangId",
                table: "MemberType",
                column: "GangId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GangMember");

            migrationBuilder.DropTable(
                name: "MemberType");

            migrationBuilder.DropTable(
                name: "Gang");
        }
    }
}

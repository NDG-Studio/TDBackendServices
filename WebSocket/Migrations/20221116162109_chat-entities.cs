using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebSocket.Migrations
{
    public partial class chatentities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChatRoom",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ChatRoomTypeId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastChangeDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatRoom", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChatRoomMember",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ChatRoomId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false),
                    LastSeen = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    JoinedRoomDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatRoomMember", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChatRoomMember_ChatRoom_ChatRoomId",
                        column: x => x.ChatRoomId,
                        principalTable: "ChatRoom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChatMessage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ChatRoomMemberId = table.Column<Guid>(type: "uuid", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: false),
                    Extention = table.Column<string>(type: "text", nullable: false),
                    ExtentionTypeId = table.Column<int>(type: "integer", nullable: false),
                    SendedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatMessage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChatMessage_ChatRoomMember_ChatRoomMemberId",
                        column: x => x.ChatRoomMemberId,
                        principalTable: "ChatRoomMember",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessage_ChatRoomMemberId",
                table: "ChatMessage",
                column: "ChatRoomMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatRoomMember_ChatRoomId",
                table: "ChatRoomMember",
                column: "ChatRoomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChatMessage");

            migrationBuilder.DropTable(
                name: "ChatRoomMember");

            migrationBuilder.DropTable(
                name: "ChatRoom");
        }
    }
}

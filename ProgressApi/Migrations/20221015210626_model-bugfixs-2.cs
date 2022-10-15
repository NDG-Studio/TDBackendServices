using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgressApi.Migrations
{
    public partial class modelbugfixs2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EnemyKill_UserProgressHistory_UserProgressId",
                table: "EnemyKill");

            migrationBuilder.DropIndex(
                name: "IX_EnemyKill_UserProgressId",
                table: "EnemyKill");

            migrationBuilder.DropColumn(
                name: "UserProgressId",
                table: "EnemyKill");

            migrationBuilder.CreateIndex(
                name: "IX_EnemyKill_UserProgressHistoryId",
                table: "EnemyKill",
                column: "UserProgressHistoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_EnemyKill_UserProgressHistory_UserProgressHistoryId",
                table: "EnemyKill",
                column: "UserProgressHistoryId",
                principalTable: "UserProgressHistory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EnemyKill_UserProgressHistory_UserProgressHistoryId",
                table: "EnemyKill");

            migrationBuilder.DropIndex(
                name: "IX_EnemyKill_UserProgressHistoryId",
                table: "EnemyKill");

            migrationBuilder.AddColumn<long>(
                name: "UserProgressId",
                table: "EnemyKill",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_EnemyKill_UserProgressId",
                table: "EnemyKill",
                column: "UserProgressId");

            migrationBuilder.AddForeignKey(
                name: "FK_EnemyKill_UserProgressHistory_UserProgressId",
                table: "EnemyKill",
                column: "UserProgressId",
                principalTable: "UserProgressHistory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

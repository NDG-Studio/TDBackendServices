using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgressApi.Migrations
{
    public partial class modelbugfixs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "BarrierHealth",
                table: "UserProgressHistory",
                type: "integer",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AddColumn<int>(
                name: "BarrierHealth",
                table: "Stage",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "DeadCount",
                table: "EnemyKill",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "UserProgressHistoryId",
                table: "EnemyKill",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_WaveDetail_WaveId",
                table: "WaveDetail",
                column: "WaveId");

            migrationBuilder.AddForeignKey(
                name: "FK_WaveDetail_Wave_WaveId",
                table: "WaveDetail",
                column: "WaveId",
                principalTable: "Wave",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WaveDetail_Wave_WaveId",
                table: "WaveDetail");

            migrationBuilder.DropIndex(
                name: "IX_WaveDetail_WaveId",
                table: "WaveDetail");

            migrationBuilder.DropColumn(
                name: "BarrierHealth",
                table: "Stage");

            migrationBuilder.DropColumn(
                name: "UserProgressHistoryId",
                table: "EnemyKill");

            migrationBuilder.AlterColumn<double>(
                name: "BarrierHealth",
                table: "UserProgressHistory",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<long>(
                name: "DeadCount",
                table: "EnemyKill",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");
        }
    }
}

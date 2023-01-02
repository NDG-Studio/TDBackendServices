using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlayerBaseApi.Migrations
{
    public partial class scoutchanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AttackerDeadSpyCount",
                table: "Scout",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AttackerSpyCount",
                table: "Scout",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DefenserDeadSpyCount",
                table: "Scout",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DefenserSpyCount",
                table: "Scout",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AttackerDeadSpyCount",
                table: "Scout");

            migrationBuilder.DropColumn(
                name: "AttackerSpyCount",
                table: "Scout");

            migrationBuilder.DropColumn(
                name: "DefenserDeadSpyCount",
                table: "Scout");

            migrationBuilder.DropColumn(
                name: "DefenserSpyCount",
                table: "Scout");
        }
    }
}

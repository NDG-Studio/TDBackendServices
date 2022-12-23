using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlayerBaseApi.Migrations
{
    public partial class poweradded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LootRunPoint",
                table: "PlayerBaseInfo",
                newName: "Power");

            migrationBuilder.AddColumn<int>(
                name: "DefenseKillCount",
                table: "PlayerBaseInfo",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DefenseKillCount",
                table: "PlayerBaseInfo");

            migrationBuilder.RenameColumn(
                name: "Power",
                table: "PlayerBaseInfo",
                newName: "LootRunPoint");
        }
    }
}

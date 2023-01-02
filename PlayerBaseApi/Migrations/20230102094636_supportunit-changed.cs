using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlayerBaseApi.Migrations
{
    public partial class supportunitchanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClientAvatarId",
                table: "SupportUnit",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ClientUsername",
                table: "SupportUnit",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HeroName",
                table: "SupportUnit",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "HostAvatarId",
                table: "SupportUnit",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "HostUsername",
                table: "SupportUnit",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientAvatarId",
                table: "SupportUnit");

            migrationBuilder.DropColumn(
                name: "ClientUsername",
                table: "SupportUnit");

            migrationBuilder.DropColumn(
                name: "HeroName",
                table: "SupportUnit");

            migrationBuilder.DropColumn(
                name: "HostAvatarId",
                table: "SupportUnit");

            migrationBuilder.DropColumn(
                name: "HostUsername",
                table: "SupportUnit");
        }
    }
}

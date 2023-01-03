using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlayerBaseApi.Migrations
{
    public partial class isabortadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAbort",
                table: "RallyPart",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsAbort",
                table: "Rally",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAbort",
                table: "RallyPart");

            migrationBuilder.DropColumn(
                name: "IsAbort",
                table: "Rally");
        }
    }
}

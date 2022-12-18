using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlayerBaseApi.Migrations
{
    public partial class rallychanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TargetTroopCount",
                table: "Rally",
                newName: "ATotalWoundedTroop");

            migrationBuilder.AddColumn<int>(
                name: "ATotalDeadTroop",
                table: "Rally",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ATotalTroop",
                table: "Rally",
                type: "integer",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ATotalDeadTroop",
                table: "Rally");

            migrationBuilder.DropColumn(
                name: "ATotalTroop",
                table: "Rally");

            migrationBuilder.RenameColumn(
                name: "ATotalWoundedTroop",
                table: "Rally",
                newName: "TargetTroopCount");
        }
    }
}

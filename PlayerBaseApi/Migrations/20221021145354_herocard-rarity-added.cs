using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlayerBaseApi.Migrations
{
    public partial class herocardrarityadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HeroCards",
                table: "PlayerBaseInfo",
                newName: "RareHeroCards");

            migrationBuilder.AddColumn<int>(
                name: "EpicHeroCards",
                table: "PlayerBaseInfo",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LegendaryHeroCards",
                table: "PlayerBaseInfo",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EpicHeroCards",
                table: "PlayerBaseInfo");

            migrationBuilder.DropColumn(
                name: "LegendaryHeroCards",
                table: "PlayerBaseInfo");

            migrationBuilder.RenameColumn(
                name: "RareHeroCards",
                table: "PlayerBaseInfo",
                newName: "HeroCards");
        }
    }
}

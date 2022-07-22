using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgressApi.Migrations
{
    public partial class minibug_fixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LevelStartTime",
                table: "UserProgress",
                newName: "StageStartTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StageStartTime",
                table: "UserProgress",
                newName: "LevelStartTime");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PlayerBaseApi.Migrations
{
    public partial class gateinfoadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GateInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GateId = table.Column<int>(type: "integer", nullable: false),
                    GangId = table.Column<string>(type: "text", nullable: true),
                    GangAvatarId = table.Column<string>(type: "text", nullable: true),
                    GangName = table.Column<string>(type: "text", nullable: true),
                    GangShortName = table.Column<string>(type: "text", nullable: true),
                    TotalTroopCount = table.Column<int>(type: "integer", nullable: true),
                    GateStateEnum = table.Column<int>(type: "integer", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GateInfo", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GateInfo");
        }
    }
}

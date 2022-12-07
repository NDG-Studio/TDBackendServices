using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PlayerBaseApi.Migrations
{
    public partial class attackentityadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Attack",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TargetUserId = table.Column<long>(type: "bigint", nullable: false),
                    AttackerTroopCount = table.Column<int>(type: "integer", nullable: false),
                    AttackerHeroId = table.Column<int>(type: "integer", nullable: false),
                    AttackerUserId = table.Column<long>(type: "bigint", nullable: false),
                    WinnerSide = table.Column<byte>(type: "smallint", nullable: true),
                    ArriveDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    ComeBackDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    ResultData = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attack", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attack");
        }
    }
}

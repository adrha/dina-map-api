using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpenParticipationPlatform.Api.Migrations
{
    public partial class CategroyColor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CategoryColor",
                table: "Categories",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryColor",
                table: "Categories");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace Apocrypha.EntityFramework.Migrations;

public partial class add_fallbacks_to_alphabet : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<string>(
                name: "FallbackDescription",
                table: "Alphabets",
                type: "longtext",
                nullable: true)
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.AddColumn<string>(
                name: "FallbackName",
                table: "Alphabets",
                type: "longtext",
                nullable: true)
            .Annotation("MySql:CharSet", "utf8mb4");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "FallbackDescription",
            table: "Alphabets");

        migrationBuilder.DropColumn(
            name: "FallbackName",
            table: "Alphabets");
    }
}

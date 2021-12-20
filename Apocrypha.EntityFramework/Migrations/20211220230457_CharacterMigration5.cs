using Microsoft.EntityFrameworkCore.Migrations;

namespace Apocrypha.EntityFramework.Migrations
{
    public partial class CharacterMigration5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "DisableNonPlaytimeEditing",
                table: "Characters",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisableNonPlaytimeEditing",
                table: "Characters");
        }
    }
}

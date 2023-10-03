using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Apocrypha.EntityFramework.Migrations
{
    public partial class PoisonCreator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatorId",
                table: "Poisons",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Poisons_CreatorId",
                table: "Poisons",
                column: "CreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Poisons_Users_CreatorId",
                table: "Poisons",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Poisons_Users_CreatorId",
                table: "Poisons");

            migrationBuilder.DropIndex(
                name: "IX_Poisons_CreatorId",
                table: "Poisons");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Poisons");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace Apocrypha.EntityFramework.Migrations
{
    public partial class TestLocalization3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TrueAllignmentId",
                table: "Characters",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Characters_TrueAllignmentId",
                table: "Characters",
                column: "TrueAllignmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Allignments_TrueAllignmentId",
                table: "Characters",
                column: "TrueAllignmentId",
                principalTable: "Allignments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Allignments_TrueAllignmentId",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_TrueAllignmentId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "TrueAllignmentId",
                table: "Characters");
        }
    }
}

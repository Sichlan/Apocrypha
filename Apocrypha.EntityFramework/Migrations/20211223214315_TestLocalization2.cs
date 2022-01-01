using Microsoft.EntityFrameworkCore.Migrations;

namespace Apocrypha.EntityFramework.Migrations
{
    public partial class TestLocalization2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AllignmentTranslation_Allignment_AllignmentId",
                table: "AllignmentTranslation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Allignment",
                table: "Allignment");

            migrationBuilder.RenameTable(
                name: "Allignment",
                newName: "Allignments");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Allignments",
                table: "Allignments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AllignmentTranslation_Allignments_AllignmentId",
                table: "AllignmentTranslation",
                column: "AllignmentId",
                principalTable: "Allignments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AllignmentTranslation_Allignments_AllignmentId",
                table: "AllignmentTranslation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Allignments",
                table: "Allignments");

            migrationBuilder.RenameTable(
                name: "Allignments",
                newName: "Allignment");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Allignment",
                table: "Allignment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AllignmentTranslation_Allignment_AllignmentId",
                table: "AllignmentTranslation",
                column: "AllignmentId",
                principalTable: "Allignment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

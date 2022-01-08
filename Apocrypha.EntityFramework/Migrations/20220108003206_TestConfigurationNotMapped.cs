using Microsoft.EntityFrameworkCore.Migrations;

namespace Apocrypha.EntityFramework.Migrations
{
    public partial class TestConfigurationNotMapped : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AllignmentTranslation_Allignments_AllignmentId",
                table: "AllignmentTranslation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AllignmentTranslation",
                table: "AllignmentTranslation");

            migrationBuilder.RenameTable(
                name: "AllignmentTranslation",
                newName: "AllignmentTranslations");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "AllignmentTranslations",
                type: "text",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AllignmentTranslations",
                table: "AllignmentTranslations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AllignmentTranslations_Allignments_AllignmentId",
                table: "AllignmentTranslations",
                column: "AllignmentId",
                principalTable: "Allignments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AllignmentTranslations_Allignments_AllignmentId",
                table: "AllignmentTranslations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AllignmentTranslations",
                table: "AllignmentTranslations");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "AllignmentTranslations");

            migrationBuilder.RenameTable(
                name: "AllignmentTranslations",
                newName: "AllignmentTranslation");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AllignmentTranslation",
                table: "AllignmentTranslation",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AllignmentTranslation_Allignments_AllignmentId",
                table: "AllignmentTranslation",
                column: "AllignmentId",
                principalTable: "Allignments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

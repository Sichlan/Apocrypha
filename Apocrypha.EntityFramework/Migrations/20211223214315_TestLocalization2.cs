using Microsoft.EntityFrameworkCore.Migrations;

namespace Apocrypha.EntityFramework.Migrations
{
    public partial class TestLocalization2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_AllignmentTranslation_Allignments_AllignmentId",
                table: "AllignmentTranslations",
                column: "AllignmentId",
                principalTable: "Allignments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
